using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Sample.WPF.Services;
using Firebase.Authentication.Sample.WPF.ViewModels;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Flows;
using Firebase.Authentication.WPF.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WPF.Client.Interfaces;
using ReCaptcha.Desktop.WPF.Client;
using Serilog;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Firebase.Authentication.Sample.WPF;

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
                services.AddTransient<ChangePasswordViewModel>();
                services.AddSingleton<LinkViewModel>();
                services.AddSingleton<LinkProviderViewModel>();
                services.AddTransient<LinkEmailViewModel>();
                services.AddTransient<LinkPhoneViewModel>();
                services.AddSingleton<MainViewModel>();

                // Add services
                services.AddSingleton<AppStartupHandler>();
                services.AddSingleton<JsonConverter>();
                services.AddSingleton<ImageUploader>();
                services.AddSingleton<IReCaptchaClient>(provider => new ReCaptchaClient(
                    new(
                        siteKey: config.ReCaptchaSiteKey,
                        config.ReCaptchaHostName),
                    new ReCaptcha.Desktop.WPF.Configuration.WindowConfig(
                        title: "Please verify the reCAPTCHA!",
                        icon: Icons.Firebase,
                        startupLocation: WindowStartupLocation.CenterOwner),
                    provider.GetRequiredService<ILogger<IReCaptchaClient>>()));

                services.AddSingleton<IAuthenticationClient>(s => new AuthenticationClient(
                    new AuthenticationConfig(
                        config.ApiKey,
                        new HttpConfig(
                            config.HttpTimeout,
                            string.IsNullOrEmpty(config.HttpProxy) ? null : new WebProxy(config.HttpProxy))),
                    s.GetRequiredService<ILogger<IAuthenticationClient>>()));
                services.AddSingleton(s => new FacebookProviderFlow(
                    CreateProviderFlowConfiguration(config, "Facebook", Icons.Facebook),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost/" : config.FlowRedirectTo));
                services.AddSingleton(s => new GoogleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Google", Icons.Google),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new AppleProviderFlow(
                    CreateProviderFlowConfiguration(config, "Apple", Icons.Apple),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new GithubProviderFlow(
                    CreateProviderFlowConfiguration(config, "Github", Icons.Github),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new TwitterProviderFlow(
                    CreateProviderFlowConfiguration(config, "Twitter", Icons.Twitter),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new MicrosoftProviderFlow(
                    CreateProviderFlowConfiguration(config, "Microsoft", Icons.Microsoft),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "http://localhost" : config.FlowRedirectTo));
                services.AddSingleton(s => new YahooProviderFlow(
                    CreateProviderFlowConfiguration(config, "Yahoo", Icons.Yahoo),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(config.FlowRedirectTo) ? "https://localhost" : config.FlowRedirectTo));
            })
            .Build();
        Provider = host.Services;
    }


    WindowConfig CreateProviderFlowConfiguration(
        Models.Configuration config,
        string provider,
        ImageSource icon) =>
        new WindowConfig(
            title: config.Title.Replace("{provider}", provider),
            icon: string.IsNullOrEmpty(config.Icon) ? icon : new BitmapImage(new(config.Icon)),
            owner: null,
            startupLocation: config.StartupLocation,
            left: config.Left,
            top: config.Top,
            showAsDialog: config.ShowAsDialog);

    protected override void OnStartup(StartupEventArgs _) =>
        Provider.GetRequiredService<AppStartupHandler>();
}