using Firebase.Authentication.Sample.WinForms.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Firebase.Authentication.Sample.WinForms;

internal static class Program
{
    public static Models.Configuration Configuration { get; private set; } = default!;

    public static InMemorySink Sink { get; } = new();
    public static SerilogLoggerFactory LoggerFactory = new(
        new LoggerConfiguration()
        .WriteTo.Debug()
        .WriteTo.Sink(Sink)
        .CreateLogger());

    public static JsonConverter JsonConverter { get; } = new(LoggerFactory.CreateLogger<JsonConverter>());

    public static MainForm MainForm { get; } = new MainForm();

    public static Form? LoggerForm { get; set; }


    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        ILogger logger = LoggerFactory.CreateLogger(typeof(Program));

        Configuration = new ConfigurationBuilder()
           .AddJsonFile("Configuration.json", true)
           .Build()
           .Get<Models.Configuration>() ?? new();

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
}