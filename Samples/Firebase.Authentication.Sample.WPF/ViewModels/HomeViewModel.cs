using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    readonly ILogger<HomeViewModel> logger;
    readonly Models.Configuration configuration;
    readonly MainViewModel mainViewModel;
    readonly IAuthenticationClient authenticaion;

    public HomeViewModel(
        ILogger<HomeViewModel> logger,
        IOptions<Models.Configuration> configuration,
        MainViewModel mainViewModel,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.mainViewModel = mainViewModel;
        this.authenticaion = authenticaion;

        logger.LogInformation("[HomeViewModel-.ctor] HomeViewModel has been initialized.");
    }

    [ObservableProperty]
    ObservableObject? currentViewModel;

    public bool Navigate<T>()
    {
        if (App.Provider.GetService<T>() is not ObservableObject viewModel)
            return false;

        CurrentViewModel = viewModel;
        logger.LogInformation("[HomeViewModel-Navigate] Navigated to view.");

        return true;
    }


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
        logger.LogInformation("[HomeViewModel-OpenBrowser] Opened browser with url.");
    }


    CancellationTokenSource? cancelSource;

    public async Task<bool> SignInAsync(
        SignInRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authenticaion.SignInAsync(request, cancelSource.Token);

            mainViewModel.Navigate<UserViewModel>();
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing in failed", "HomeViewModel-SignUpAsync");
        }
        return false;
    }

    public async Task<bool> SignUpAsync(
        SignUpRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authenticaion.SignUpAsync(request, cancelSource.Token);

            mainViewModel.Navigate<UserViewModel>();
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing up failed", "HomeViewModel-SignUpAsync");
        }
        return false;
    }
}