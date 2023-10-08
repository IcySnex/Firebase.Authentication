#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Sample.UWP.Services;
using Firebase.Authentication.UWP.Client;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Flows;
using Firebase.Authentication.UWP.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Security.Authentication.Web;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    readonly ILogger<HomeViewModel> logger;
    readonly Models.Configuration configuration;
    readonly Navigation navigation;

    public HomeViewModel(
        ILogger<HomeViewModel> logger,
        IOptions<Models.Configuration> configuration,
        Navigation navigation)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.navigation = navigation;

        logger.LogInformation("[HomeViewModel-.ctor] HomeViewModel has been initialized.");
    }


    [ObservableProperty]
    Page? currentView;

    public void Navigate(
        Page? view)
    {
        CurrentView = view;
        logger.LogInformation("[HomeViewModel.Navigate] Navigated to view.");
    }


    [RelayCommand]
    async Task OpenBrowserAsync(
        string url)
    {
        await Launcher.LaunchUriAsync(new(url));
        logger.LogInformation("[HomeViewModel-OpenBrowser] Opened browser with url.");
    }


    [RelayCommand]
    async Task AuthAsync()
    {
        IProviderFlow flow = new MicrosoftProviderFlow(new());
        IAuthenticationClient client = new AuthenticationClient(new Configuration.AuthenticationConfig("AIzaSyALFTcLBy2mjtgCjKfIJ82Ivu-wVR3w9Z4"));

        await flow.SignInAsync(client);
    }
}