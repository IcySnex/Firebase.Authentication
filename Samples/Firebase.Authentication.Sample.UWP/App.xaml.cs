#nullable enable

using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Sample.UWP.Services;
using Firebase.Authentication.Sample.UWP.ViewModels;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Flows;
using Firebase.Authentication.UWP.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.UWP.Client;
using ReCaptcha.Desktop.UWP.Client.Interfaces;
using Serilog;
using System;
using System.Net;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

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
                services.AddSingleton<UserViewModel>();
                services.AddTransient<ProviderViewModel>();
                services.AddTransient<EmailViewModel>();
                services.AddTransient<PhoneViewModel>();
                services.AddSingleton<LinkViewModel>();
                services.AddSingleton<LinkProviderViewModel>();
                services.AddSingleton<LinkEmailViewModel>();
                services.AddSingleton<LinkPhoneViewModel>();

                // Add services
                services.AddSingleton<AppStartupHandler>();
                services.AddSingleton<Navigation>();
                services.AddSingleton<JsonConverter>();
                services.AddSingleton<ImageUploader>();
                services.AddSingleton<IReCaptchaClient>(provider => new ReCaptchaClient(
                    new(
                        siteKey: config.ReCaptchaSiteKey,
                        config.ReCaptchaHostName),
                    new ReCaptcha.Desktop.UWP.Configuration.PopupConfig(
                        title: "Please verify the reCAPTCHA!",
                        icon: Icons.ToImageSource(Helpers.Icons.ReCaptcha)),
                    provider.GetRequiredService<ILogger<IReCaptchaClient>>()));

                services.AddSingleton<IAuthenticationClient>(s => new AuthenticationClient(
                    new AuthenticationConfig(
                        config.ApiKey,
                        new HttpConfig(
                            config.HttpTimeout,
                            string.IsNullOrEmpty(config.HttpProxy) ? null : new WebProxy(config.HttpProxy))),
                    s.GetRequiredService<ILogger<IAuthenticationClient>>()));
                services.AddSingleton(s => new FacebookProviderFlow(
                    CreateProviderFlowConfiguration(config, "Facebook", Icons.ToImageSource(Icons.Facebook)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost/" : config.FlowRedirectTo));
                services.AddSingleton(s => new GoogleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Google", Icons.ToImageSource(Icons.Google)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new AppleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Apple", Icons.ToImageSource(Icons.Apple)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new GithubProviderFlow(
                    CreateProviderFlowConfiguration(config, "Github", Icons.ToImageSource(Icons.Github)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new TwitterProviderFlow(
                    CreateProviderFlowConfiguration(config, "Twitter", Icons.ToImageSource(Icons.Twitter)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new MicrosoftProviderFlow(
                    CreateProviderFlowConfiguration(config, "Microsoft", Icons.ToImageSource(Icons.Microsoft)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new YahooProviderFlow(
                    CreateProviderFlowConfiguration(config, "Yahoo", Icons.ToImageSource(Icons.Yahoo)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
            })
            .Build();
        Provider = host.Services;

        InitializeComponent();
    }

    PopupConfig CreateProviderFlowConfiguration(
        Models.Configuration config,
        string provider,
        ImageSource icon) =>
        new PopupConfig(
            title: config.Title.Replace("{provider}", provider),
            icon: string.IsNullOrEmpty(config.Icon) ? icon : Icons.ToImageSource(Icons.Firebase),
            hasTitleBar: config.HasTitleBar,
            isDraggable: config.IsDragable,
            isDimmed: config.IsDimmed,
            startupLocation: config.StartupLocation,
            left: config.Left,
            top: config.Top);


    protected override void OnLaunched(LaunchActivatedEventArgs e) =>
        Provider.GetRequiredService<AppStartupHandler>();
}