using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Sample.WinUI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Windows.AppLifecycle;

namespace Firebase.Authentication.Sample.WinUI.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    readonly JsonConverter converter;

    public Models.Configuration Configuration { get; }

    public SettingsViewModel(
        ILogger<SettingsViewModel> logger,
        IOptions<Models.Configuration> configuration,
        JsonConverter converter)
    {
        this.converter = converter;

        Configuration = configuration.Value;

        logger.LogInformation("[SettingsViewModel-.ctor] SettingsViewModel has been initialized.");
    }


    [RelayCommand]
    async Task RestartAppAsync()
    {
        string config = converter.ToString(Configuration);
        await File.WriteAllTextAsync("Configuration.json", config);

        AppInstance.Restart("");
    }
}