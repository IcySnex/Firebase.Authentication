using Firebase.Authentication.Sample.WinUI.ViewModels;
using Firebase.Authentication.Sample.WinUI.Views;
using Firebase.Authentication.WinUI.Flows;
using Firebase.Authentication.WinUI.UI;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.UI.Xaml;
using ReCaptcha.Desktop.WinUI.Client.Interfaces;
using System;

namespace Firebase.Authentication.Sample.WinUI.Services;

public class AppStartupHandler
{
    public AppStartupHandler(
        ILogger<AppStartupHandler> logger,
        IOptions<Models.Configuration> configuration,
        MainView mainView,
        WindowHelper windowHelper,
        Navigation navigation,
        JsonConverter converter,
        HomeViewModel homeViewModel,
        //LinkViewModel linkViewModel,
        IReCaptchaClient reCaptcha,
        FacebookProviderFlow facebookFlow,
        GoogleProviderFlow googleFlow,
        AppleProviderFlow appleFlow,
        GithubProviderFlow githubFlow,
        TwitterProviderFlow twitterFlow,
        MicrosoftProviderFlow microsoftFlow,
        YahooProviderFlow yahooFlow)
    {
        try
        {
            ((Style)App.Current.Resources["SignInButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.SignIn, 19, 19)));
            ((Style)App.Current.Resources["CancelButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Helpers.Icons.Cancel, 19, 19)));


            reCaptcha.WindowConfiguration.Owner = mainView;

            facebookFlow.WindowConfiguration.Owner = mainView;
            googleFlow.WindowConfiguration.Owner = mainView;
            appleFlow.WindowConfiguration.Owner = mainView;
            githubFlow.WindowConfiguration.Owner = mainView;
            twitterFlow.WindowConfiguration.Owner = mainView;
            microsoftFlow.WindowConfiguration.Owner = mainView;
            yahooFlow.WindowConfiguration.Owner = mainView;

            windowHelper.SetTitleBar(mainView.TitleBarDragArea, mainView.TitleBarContainer);
            windowHelper.SetIcon(Icons.ToBitmap(Icons.Firebase));
            windowHelper.SetSize(500, 930);

            mainView.Closed += async (s, e) =>
            {
                windowHelper.LoggerView?.Close();

                string config = converter.ToString(configuration.Value);
                await File.WriteAllTextAsync("Configuration.json", config);

                logger.LogInformation("[MainView-Closed] Closed main window");
            };
            mainView.Activate();

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