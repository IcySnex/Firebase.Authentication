#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.UWP.Flows;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class LinkProviderViewModel : ObservableObject
{
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
    void NavigateToEmail() =>
        linkViewModel.NavigateToEmail();

    [RelayCommand]
    void NavigateToPhone() =>
        linkViewModel.NavigateToPhone();


    [RelayCommand]
    Task LinkToFlowAsync(
        IProviderFlow flow) =>
        linkViewModel.LinkAsync(LinkRequest.ToProviderFlow(flow));
}