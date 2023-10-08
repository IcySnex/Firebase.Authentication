#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Sample.UWP.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

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
        StorageFile configFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Configuration.json", CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(configFile, config);

        await CoreApplication.RequestRestartAsync("");
    }
}