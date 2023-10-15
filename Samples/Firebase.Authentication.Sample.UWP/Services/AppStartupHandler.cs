#nullable enable

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.Storage;
using System;
using Firebase.Authentication.UWP.UI;

namespace Firebase.Authentication.Sample.UWP.Services;

public class AppStartupHandler
{
    public AppStartupHandler(
        ILogger<AppStartupHandler> logger,
        IOptions<Models.Configuration> configuration,
        Navigation navigation,
        JsonConverter converter)
    {
        FirebaseAuthenticationDictionary.LoadIcons(App.Current.Resources);


        ApplicationView.PreferredLaunchViewSize = new(900, 700);

        ApplicationView appView = ApplicationView.GetForCurrentView();
        appView.SetPreferredMinSize(new(495, 930));

        CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        appView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
        appView.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

        Window.Current.Closed += async (s, e) =>
        {
            if (App.LoggerWindow is not null)
                await App.LoggerWindow.CloseAsync();

            string config = converter.ToString(configuration.Value);
            StorageFile configFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Configuration.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(configFile, config);

            logger.LogInformation("[Window.Current-Closed] Closed main window");
        };
        Window.Current.Activate();

        navigation.Navigate("Home");

        logger.LogInformation("[AppStartupHandler-.ctor] App fully started.");
    }
}