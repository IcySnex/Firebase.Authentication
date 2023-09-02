using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.WPF.Flows;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class LinkProviderViewModel : ObservableObject
{
    readonly MainViewModel mainViewModel;
    readonly LinkViewModel linkViewModel;

    public UserViewModel UserViewModel { get; }
    public IProviderFlow FacebookFlow { get; }
    public IProviderFlow GoogleFlow { get; }
    public IProviderFlow AppleFlow { get; }
    public IProviderFlow GithubFlow { get; }
    public IProviderFlow TwitterFlow { get; }
    public IProviderFlow MicrosoftFlow { get; }
    public IProviderFlow YahooFlow { get; }

    public LinkProviderViewModel(
        ILogger<ProviderViewModel> logger,
        MainViewModel mainViewModel,
        UserViewModel userViewModel,
        LinkViewModel linkViewModel,
        FacebookProviderFlow facebookFlow,
        GoogleProviderFlow googleFlow,
        AppleProviderFlow appleFlow,
        GithubProviderFlow githubFlow,
        TwitterProviderFlow twitterFlow,
        MicrosoftProviderFlow microsoftFlow,
        YahooProviderFlow yahooFlow)
    {
        this.mainViewModel = mainViewModel;
        this.linkViewModel = linkViewModel;

        UserViewModel = userViewModel;
        FacebookFlow = facebookFlow;
        GoogleFlow = googleFlow;
        AppleFlow = appleFlow;
        GithubFlow = githubFlow;
        TwitterFlow = twitterFlow;
        MicrosoftFlow = microsoftFlow;
        YahooFlow = yahooFlow;

        logger.LogInformation("[LinkProviderViewModel-.ctor] ProviderViewModel has been initialized.");
    }


    [RelayCommand]
    void Cancel() =>
        mainViewModel.CloseModal();


    [RelayCommand]
    void NavigateToEmail() =>
        linkViewModel.Navigate<LinkEmailViewModel>();

    [RelayCommand]
    void NavigateToPhone() =>
        linkViewModel.Navigate<LinkPhoneViewModel>();


    [RelayCommand]
    Task LinkToFlowAsync(
        IProviderFlow flow) =>
        linkViewModel.LinkAsync(LinkRequest.ToProviderFlow(flow));
}