using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Sample.WPF.Services;
using Firebase.Authentication.Sample.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using Firebase.Authentication.Client.Interfaces;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    readonly ILogger<MainViewModel> logger;
    readonly Models.Configuration configuration;
    readonly JsonConverter jsonConverter;

    public IAuthenticationClient Authentication { get; }

    readonly public MainView MainView;

    public MainViewModel(
        ILogger<MainViewModel> logger,
        IOptions<Models.Configuration> configuration,
        JsonConverter jsonConverter,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.jsonConverter = jsonConverter;
        Authentication = authentication;

        MainView = new() { DataContext = this };
        MainView.Show();

        MainView.Closed += (s, e) => PrepareAppShutdown();

        logger.LogInformation("[MainViewModel-.ctor] MainViewModel has been initialized.");
    }


    public void RestartApp()
    {
        logger.LogInformation("[MainViewModel-RestartApp] App restart requested.");

        PrepareAppShutdown();

        Process.Start(Environment.ProcessPath!);
        Process.GetCurrentProcess().Kill();
    }

    void PrepareAppShutdown()
    {
        LoggerWindow?.Close();

        string config = jsonConverter.ToString(configuration);
        File.WriteAllText("Configuration.json", config);

        logger.LogInformation("[MainView-PrepareAppShutdown] Prepared app shutdown.");
    }


    [ObservableProperty]
    ObservableObject? currentViewModel;

    public bool Navigate<T>()
    {
        if (App.Provider.GetService<T>() is not ObservableObject viewModel)
            return false;

        CurrentViewModel = viewModel;
        logger.LogInformation("[MainViewModel-Navigate] Navigated to view.");

        return true;
    }


    [RelayCommand]
    void NavigateToHome() =>
        Navigate<HomeViewModel>();
    
    [RelayCommand]
    void NavigateToUser() =>
        Navigate<UserViewModel>();

    [RelayCommand]
    void NavigateToSettings() =>
        Navigate<SettingsViewModel>();


    [RelayCommand]
    void OpenBrowser(
        string url)
    {
        Process.Start(new ProcessStartInfo()
        {
            FileName = url,
            UseShellExecute = true,
            CreateNoWindow = true
        });
        logger.LogInformation("[MainViewModel-OpenBrowser] Opened browser with url.");
    }


    public Window? LoggerWindow;

    [RelayCommand]
    void CreateLogger()
    {
        if (LoggerWindow is not null)
        {
            LoggerWindow.Activate();
            return;
        }

        TextBox textBox = new()
        {
            IsReadOnly = true,
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        ScrollViewer.SetVerticalScrollBarVisibility(textBox, ScrollBarVisibility.Auto);
        ScrollViewer.SetHorizontalScrollBarVisibility(textBox, ScrollBarVisibility.Auto);

        Window window = new()
        {
            Title = "WPF Sample - Firebase Authenticaion (Logger)",
            Width = 600,
            Height = 400,
            Content = textBox
        };

        void handler(object? s, string e) =>
            textBox.Text += e;

        App.Sink.OnNewLog += handler;
        window.Closed += (s, e) =>
        {
            App.Sink.OnNewLog -= handler;
            LoggerWindow = null;
        };

        LoggerWindow = window;
        LoggerWindow.Show();

        logger.LogInformation("[HomeViewModel-CreateLoggerWindow] Created new LoggerWindow and hooked handler.");
    }
}