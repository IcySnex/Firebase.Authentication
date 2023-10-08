using Firebase.Authentication.Sample.WinUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Serilog;
using Firebase.Authentication.WinUI.Configuration;
using System.Drawing;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WinUI.Client.Interfaces;
using ReCaptcha.Desktop.WinUI.Client;
using System.Net;
using Firebase.Authentication.WinUI.UI;
using Firebase.Authentication.WinUI.Flows;
using Firebase.Authentication.Sample.WinUI.Views;
using Firebase.Authentication.Sample.WinUI.ViewModels;

namespace Firebase.Authentication.Sample.WinUI;

public partial class App : Application
{
    readonly IHost host;

    public static IServiceProvider Provider { get; private set; } = default!;
    public static InMemorySink Sink { get; private set; } = new();

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
                builder.AddJsonFile("Configuration.json", true);
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

                services.AddSingleton<MainView>();

                // Add services
                services.AddSingleton<AppStartupHandler>();
                services.AddSingleton<WindowHelper>();
                services.AddSingleton<Navigation>();
                services.AddSingleton<JsonConverter>();
                services.AddSingleton<ImageUploader>();
                services.AddSingleton<IReCaptchaClient>(provider => new ReCaptchaClient(
                    new(
                        siteKey: config.ReCaptchaSiteKey,
                        config.ReCaptchaHostName),
                    new ReCaptcha.Desktop.WinUI.Configuration.WindowConfig(
                        title: "Please verify the reCAPTCHA!",
                        startupLocation: ReCaptcha.Desktop.WinUI.Configuration.WindowStartupLocation.CenterOwner,
                        showAsDialog: true),
                    provider.GetRequiredService<ILogger<IReCaptchaClient>>()));

                services.AddSingleton<IAuthenticationClient>(s => new AuthenticationClient(
                    new AuthenticationConfig(
                        config.ApiKey,
                        new HttpConfig(
                            config.HttpTimeout,
                            string.IsNullOrEmpty(config.HttpProxy) ? null : new WebProxy(config.HttpProxy))),
                    s.GetRequiredService<ILogger<IAuthenticationClient>>()));
                services.AddSingleton(s => new FacebookProviderFlow(
                    CreateProviderFlowConfiguration(config, "Facebook", Icons.ToBitmap(Icons.Facebook)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost/" : config.FlowRedirectTo));
                services.AddSingleton(s => new GoogleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Google", Icons.ToBitmap(Icons.Google)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new AppleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Apple", Icons.ToBitmap(Icons.Apple)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new GithubProviderFlow(
                    CreateProviderFlowConfiguration(config, "Github", Icons.ToBitmap(Icons.Github)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new TwitterProviderFlow(
                    CreateProviderFlowConfiguration(config, "Twitter", Icons.ToBitmap(Icons.Twitter)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new MicrosoftProviderFlow(
                    CreateProviderFlowConfiguration(config, "Microsoft", Icons.ToBitmap(Icons.Microsoft)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new YahooProviderFlow(
                    CreateProviderFlowConfiguration(config, "Yahoo", Icons.ToBitmap(Icons.Yahoo)),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
            })
            .Build();
        Provider = host.Services;

        InitializeComponent();
    }

    WindowConfig CreateProviderFlowConfiguration(
        Models.Configuration config,
        string provider,
        Bitmap icon) =>
        new WindowConfig(
            title: config.Title.Replace("{provider}", provider),
            icon: string.IsNullOrEmpty(config.Icon) ? icon : new(config.Icon),
            owner: null,
            startupLocation: config.StartupLocation,
            left: config.Left,
            top: config.Top,
            showAsDialog: config.ShowAsDialog);


    protected override void OnLaunched(LaunchActivatedEventArgs args) =>
        Provider.GetRequiredService<AppStartupHandler>();
}