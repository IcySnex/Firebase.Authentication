#nullable enable

using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Views;
using Firebase.Authentication.UWP.Flows;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

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
        GoogleFlow = googleFlow;
        AppleFlow = appleFlow;
        GithubFlow = githubFlow;
        TwitterFlow = twitterFlow;
        MicrosoftFlow = microsoftFlow;
        YahooFlow = yahooFlow;

        logger.LogInformation("[ProviderViewModel-.ctor] ProviderViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateToEmail() =>
        homeViewModel.Navigate(new EmailView());

    [RelayCommand]
    void NavigateToPhone() =>
        homeViewModel.Navigate(new PhoneView());


    [RelayCommand]
    Task SignInWithFlowAsync(
        IProviderFlow flow) =>
        homeViewModel.SignInAsync(SignInRequest.WithProviderFlow(flow));


    [RelayCommand]
    async Task SignUpAnonymouslyAsync() =>
        await homeViewModel.SignUpAsync(SignUpRequest.Anonymously());

}