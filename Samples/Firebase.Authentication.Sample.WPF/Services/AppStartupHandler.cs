using Firebase.Authentication.Sample.WPF.ViewModels;
using Firebase.Authentication.WPF.Flows;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WPF.Client.Interfaces;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.Services;

public class AppStartupHandler
{
    public AppStartupHandler(
        ILogger<AppStartupHandler> logger,
        MainViewModel mainViewModel,
        HomeViewModel homeViewModel,
        LinkViewModel linkViewModel,
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
            reCaptcha.WindowConfiguration.Owner = mainViewModel.MainView;

            facebookFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            googleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            appleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            githubFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            twitterFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            microsoftFlow.WindowConfiguration.Owner = mainViewModel.MainView;
            yahooFlow.WindowConfiguration.Owner = mainViewModel.MainView;

            mainViewModel.Navigate<HomeViewModel>();
            homeViewModel.Navigate<ProviderViewModel>();
            linkViewModel.Navigate<LinkProviderViewModel>();

            logger.LogInformation("[AppStartupHandler-.ctor] App fully started.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("The initialization of the app was unsuccessful. " + ex.Message, "App startup failed!", MessageBoxButton.OK, MessageBoxImage.Error);
            logger.LogInformation("[AppStartupHandler-.ctor] App failed to start.");

            App.Current.Shutdown();
        }

    }
}