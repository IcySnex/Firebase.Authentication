using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.WPF.Flows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class ProviderViewModel : ObservableObject
{
    readonly HomeViewModel homeViewModel;

    public IProviderFlow FacebookFlow { get; }
    public IProviderFlow GoogleFlow { get; }
    public IProviderFlow AppleFlow { get; }
    public IProviderFlow GithubFlow { get; }
    public IProviderFlow TwitterFlow { get; }
    public IProviderFlow MicrosoftFlow { get; }
    public IProviderFlow YahooFlow { get; }

    public ProviderViewModel(
        ILogger<ProviderViewModel> logger,
        MainViewModel mainViewModel,
        HomeViewModel homeViewModel,
        FacebookProviderFlow facebookFlow,
        GoogleProviderFlow googleFlow,
        AppleProviderFlow appleFlow,
        GithubProviderFlow githubFlow,
        TwitterProviderFlow twitterFlow,
        MicrosoftProviderFlow microsoftFlow,
        YahooProviderFlow yahooFlow)
    {
        this.homeViewModel = homeViewModel;

        FacebookFlow = facebookFlow;
        facebookFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        GoogleFlow = googleFlow;
        googleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        AppleFlow = appleFlow;
        appleFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        GithubFlow = githubFlow;
        githubFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        TwitterFlow = twitterFlow;
        twitterFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        MicrosoftFlow = microsoftFlow;
        microsoftFlow.WindowConfiguration.Owner = mainViewModel.MainView;
        YahooFlow = yahooFlow;
        yahooFlow.WindowConfiguration.Owner = mainViewModel.MainView;

        logger.LogInformation("[ProviderViewModel-.ctor] ProviderViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateToEmail() =>
        homeViewModel.Navigate<EmailViewModel>();


    [RelayCommand]
    Task SignInWithFlowAsync(
        IProviderFlow flow) =>
        homeViewModel.SignInAsync(SignInRequest.WithProviderFlow(flow));
}