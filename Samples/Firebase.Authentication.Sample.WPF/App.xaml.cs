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
                Models.Configuration configuration = context.Configuration.Get<Models.Configuration>() ?? new();

                // Add ViewModels and MainView
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<UserViewModel>();
                services.AddSingleton<ProviderViewModel>();
                services.AddTransient<EmailViewModel>();
                services.AddTransient<PhoneViewModel>();
                services.AddTransient<AnonymouslyViewModel>();
                services.AddSingleton<MainViewModel>();

                // Add services
                services.AddSingleton<AppStartupHandler>();
                services.AddSingleton<JsonConverter>();

                services.AddSingleton<IReCaptchaClient>(provider => new ReCaptchaClient(
                    default!,
                    new ReCaptcha.Desktop.WPF.Configuration.WindowConfig(
                        title: "Please verify the reCAPTCHA!",
                        icon: Icons.Firebase,
                        startupLocation: WindowStartupLocation.CenterOwner),
                    provider.GetRequiredService<ILogger<IReCaptchaClient>>()));

                services.AddSingleton<IAuthenticationClient>(s => new AuthenticationClient(
                    new AuthenticationConfig(
                        configuration.ApiKey,
                        new HttpConfig(
                            configuration.HttpTimeout,
                            string.IsNullOrEmpty(configuration.HttpProxy) ? null : new WebProxy(configuration.HttpProxy))),
                    s.GetRequiredService<ILogger<IAuthenticationClient>>()));

                services.AddSingleton(s => new FacebookProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Facebook", Icons.Facebook),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "https://localhost/" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new GoogleProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Google", Icons.Google),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "http://localhost" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new AppleProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Apple", Icons.Apple),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "https://localhost" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new GithubProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Github", Icons.Github),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "http://localhost" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new TwitterProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Twitter", Icons.Twitter),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "http://localhost" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new MicrosoftProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Microsoft", Icons.Microsoft),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "http://localhost" : configuration.FlowRedirectTo));
                services.AddSingleton(s => new YahooProviderFlow(
                    CreateProviderFlowConfiguration(configuration, "Yahoo", Icons.Yahoo),
                    s.GetRequiredService<ILogger<IProviderFlow>>(),
                    string.IsNullOrEmpty(configuration.FlowRedirectTo) ? "https://localhost" : configuration.FlowRedirectTo));
            })
            .Build();
        Provider = host.Services;
    }


    WindowConfig CreateProviderFlowConfiguration(
        Models.Configuration configuration,
        string provider,
        ImageSource icon) =>
        new WindowConfig(
            title: configuration.Title.Replace("{provider}", provider),
            icon: string.IsNullOrEmpty(configuration.Icon) ? icon : new BitmapImage(new(configuration.Icon)),
            owner: null,
            startupLocation: configuration.StartupLocation,
            left: configuration.Left,
            top: configuration.Top,
            showAsDialog: configuration.ShowAsDialog);

    protected override async void OnStartup(StartupEventArgs _) =>
        await Provider.GetRequiredService<AppStartupHandler>().InitializeAsync();
}