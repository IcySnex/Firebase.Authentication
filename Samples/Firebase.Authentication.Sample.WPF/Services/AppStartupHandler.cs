using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Sample.WPF.ViewModels;
using Firebase.Authentication.WPF.Flows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReCaptcha.Desktop.WPF.Client.Interfaces;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.Services;

public class AppStartupHandler
{
    readonly ILogger<AppStartupHandler> logger;
    readonly Models.Configuration config;
    readonly MainViewModel mainViewModel;
    readonly HomeViewModel homeViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authenticaion;

    public AppStartupHandler(
        ILogger<AppStartupHandler> logger,
        IOptions<Models.Configuration> config,
        MainViewModel mainViewModel,
        HomeViewModel homeViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authenticaion,
        FacebookProviderFlow facebookFlow,
        GoogleProviderFlow googleFlow,
        AppleProviderFlow appleFlow,
        GithubProviderFlow githubFlow,
        TwitterProviderFlow twitterFlow,
        MicrosoftProviderFlow microsoftFlow,
        YahooProviderFlow yahooFlow)
    {
        this.logger = logger;
        this.config = config.Value;
        this.mainViewModel = mainViewModel;
        this.homeViewModel = homeViewModel;
        this.reCaptcha = reCaptcha;
        this.authenticaion = authenticaion;

        facebookFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        googleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        appleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        githubFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        twitterFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        microsoftFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        yahooFlow.WindowConfiguration.Owner = mainViewModel.MainView;
    }


    public async Task InitializeAsync()
    {
        try
        {
            reCaptcha.Configuration = new(await authenticaion.GetRecaptchaSiteKeyAsync(), config.ReCaptchaHostName);
            reCaptcha.WindowConfiguration.Owner = mainViewModel.MainView;

            mainViewModel.Navigate<HomeViewModel>();
            homeViewModel.Navigate<ProviderViewModel>();

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