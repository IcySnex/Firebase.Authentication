using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    readonly ILogger<SettingsViewModel> logger;

    public Models.Configuration Configuration { get; }

    public SettingsViewModel(
        ILogger<SettingsViewModel> logger,
        IOptions<Models.Configuration> configuration)
    {
        this.logger = logger;

        Configuration = configuration.Value;

        logger.LogInformation("[SettingsViewModel-.ctor] SettingsViewModel has been initialized.");
    }


    [RelayCommand]
    void RestartApp()
    {
        logger.LogInformation("[SettingsViewModel-RestartApp] App restart requested.");

        App.Current.Shutdown();
        Process.Start(Environment.ProcessPath!);
    }
}