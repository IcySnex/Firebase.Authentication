#nullable enable

using Firebase.Authentication.Sample.UWP.Services;
using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;

namespace Firebase.Authentication.Sample.UWP;

sealed partial class App : Application
{
    readonly IHost host;

    public static IServiceProvider Provider { get; private set; } = default!;
    public static InMemorySink Sink { get; private set; } = new();
    public static AppWindow? LoggerWindow = null;

    public App()
    {
        host = Host.CreateDefaultBuilder()
            .UseSerilog((context, configuration) =>
            {
                configuration.WriteTo.Debug();
                configuration.WriteTo.Sink(Sink);
            })
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddJsonFile($@"{ApplicationData.Current.LocalFolder.Path}\Configuration.json", true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<Models.Configuration>(context.Configuration);
                Models.Configuration config = context.Configuration.Get<Models.Configuration>() ?? new();

                // Add ViewModels and MainView
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<SettingsViewModel>();

                // Add services
                services.AddSingleton<AppStartupHandler>();
                services.AddSingleton<Navigation>();
                services.AddSingleton<JsonConverter>();
            })
            .Build();
        Provider = host.Services;

        InitializeComponent();

    }


    protected override void OnLaunched(LaunchActivatedEventArgs e) =>
        Provider.GetRequiredService<AppStartupHandler>();
}