using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Sample.WinForms.Services;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Flows;
using Firebase.Authentication.WinForms.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System.Net;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Firebase.Authentication.Sample.WinForms;

internal static class Program
{
    public static readonly Models.Configuration Configuration = new ConfigurationBuilder()
        .AddJsonFile("Configuration.json", true)
        .Build()
        .Get<Models.Configuration>() ?? new();

    public static readonly InMemorySink Sink = new();
    public static readonly SerilogLoggerFactory LoggerFactory = new(
        new LoggerConfiguration()
        .WriteTo.Debug()
        .WriteTo.Sink(Sink)
        .CreateLogger());

    public static MainForm MainForm { get; } = new MainForm();
    public static Form? LoggerForm { get; set; }

    public static readonly JsonConverter JsonConverter = new(LoggerFactory.CreateLogger<JsonConverter>());
    public static readonly ImageUploader ImageUploader = new(LoggerFactory.CreateLogger<ImageUploader>(), Configuration, JsonConverter);

    public static readonly IAuthenticationClient Authentication = new AuthenticationClient(new AuthenticationConfig(
        Configuration.ApiKey,
        new HttpConfig(
            Configuration.HttpTimeout,
            string.IsNullOrEmpty(Configuration.HttpProxy) ? null : new WebProxy(Configuration.HttpProxy))),
        LoggerFactory.CreateLogger<IAuthenticationClient>());
    public static readonly IProviderFlow FacebookFlow = new FacebookProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Facebook", Icons.ToIcon(Icons.Facebook)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "https://localhost/" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow GoogleFlow = new GoogleProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Google", Icons.ToIcon(Icons.Google)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "http://localhost" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow AppleFlow = new AppleProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Apple", Icons.ToIcon(Icons.Apple)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "https://localhost" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow GithubFlow = new GithubProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Github", Icons.ToIcon(Icons.Github)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "http://localhost" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow TwitterFlow = new TwitterProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Twitter", Icons.ToIcon(Icons.Twitter)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "http://localhost" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow MicrosoftFlow = new MicrosoftProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Microsoft", Icons.ToIcon(Icons.Microsoft)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "http://localhost" : Configuration.FlowRedirectTo);
    public static readonly IProviderFlow YahooFlow = new YahooProviderFlow(
        CreateProviderFlowConfiguration(Configuration, "Yahoo", Icons.ToIcon(Icons.Yahoo)),
        LoggerFactory.CreateLogger<IProviderFlow>(),
        string.IsNullOrEmpty(Configuration.FlowRedirectTo) ? "https://localhost" : Configuration.FlowRedirectTo);


    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        ILogger logger = LoggerFactory.CreateLogger(typeof(Program));

        MainForm.FormClosed += (s, e) =>
        {
            LoggerForm?.Close();

            string config = JsonConverter.ToString(Configuration);
            File.WriteAllText("Configuration.json", config);

            logger.LogInformation("[MainForm-FormClosed] Closed main form");
        };

        Application.Run(MainForm);
        logger.LogInformation("[Program-Main] App fully started");
    }


    public static FormConfig CreateProviderFlowConfiguration(
        Models.Configuration config,
        string provider,
        Icon icon) =>
        new FormConfig(
            title: config.Title.Replace("{provider}", provider),
            icon: icon,
            parent: MainForm,
            startPosition: config.StartPosition,
            left: config.Left,
            top: config.Top,
            showAsDialog: config.ShowAsDialog);
}