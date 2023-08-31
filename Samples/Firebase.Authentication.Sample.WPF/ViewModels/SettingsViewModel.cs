using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    readonly MainViewModel mainViewModel;

    public Models.Configuration Configuration { get; }

    public SettingsViewModel(
        ILogger<SettingsViewModel> logger,
        IOptions<Models.Configuration> configuration,
        MainViewModel mainViewModel)
    {
        this.mainViewModel = mainViewModel;
        Configuration = configuration.Value;

        logger.LogInformation("[SettingsViewModel-.ctor] SettingsViewModel has been initialized.");
    }


    [RelayCommand]
    void RestartApp() =>
        mainViewModel.RestartApp();
}