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
using Firebase.Authentication.Sample.UWP.ViewModels;
using Firebase.Authentication.Sample.UWP.Views;

namespace Firebase.Authentication.Sample.UWP.Services;

public class AppStartupHandler
{
    public AppStartupHandler(
        ILogger<AppStartupHandler> logger,
        IOptions<Models.Configuration> configuration,
        Navigation navigation,
        JsonConverter converter,
        HomeViewModel homeViewModel)
    {
        try
        {
            FirebaseAuthenticationDictionary.LoadIcons(App.Current.Resources);
            ((Style)App.Current.Resources["SignInButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.SignIn, 19, 19)));
            ((Style)App.Current.Resources["CancelButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.Cancel, 19, 19)));
            //((Style)App.Current.Resources["RefreshButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.Refresh, 19, 19)));
            //((Style)App.Current.Resources["SignOutButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.SignOut, 19, 19)));
            //((Style)App.Current.Resources["DeleteButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.Delete, 19, 19)));


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

            homeViewModel.Navigate(new ProviderView());
            navigation.Navigate("Home");

            logger.LogInformation("[AppStartupHandler-.ctor] App fully started.");
        }
        catch (Exception ex)
        {
            logger.LogInformation($"[AppStartupHandler-.ctor] App failed to start: {ex.Message}");

            App.Current.Exit();
        }
    }
}