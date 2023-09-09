using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WinUI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.UI.Xaml.Controls;
using Windows.System;

namespace Firebase.Authentication.Sample.WinUI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    readonly ILogger<HomeViewModel> logger;
    readonly Models.Configuration configuration;
    readonly WindowHelper windowHelper;
    readonly Navigation navigation;
    readonly IAuthenticationClient authentication;

    public HomeViewModel(
        ILogger<HomeViewModel> logger,
        IOptions<Models.Configuration> configuration,
        WindowHelper windowHelper,
        Navigation navigation,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.configuration = configuration.Value;
        this.windowHelper = windowHelper;
        this.navigation = navigation;
        this.authentication = authentication;

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


    CancellationTokenSource? cancelSource;

    public async Task<bool> SignInAsync(
        SignInRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authentication.SignInAsync(request, cancelSource.Token);

            navigation.NavigateSilent("User");
            navigation.SetNavigationViewItemVisibility(0, false);
            navigation.SetNavigationViewItemVisibility(1, true);
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            await windowHelper.AlertErrorAsync(ex, "Signing in failed", "HomeViewModel-SignUpAsync");
        }
        return false;
    }

    public async Task<bool> SignUpAsync(
        SignUpRequest request)
    {
        try
        {
            cancelSource = new(configuration.Timeout);
            await authentication.SignUpAsync(request, cancelSource.Token);

            navigation.NavigateSilent("User");
            navigation.SetNavigationViewItemVisibility(0, false);
            navigation.SetNavigationViewItemVisibility(1, true);
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            await windowHelper.AlertErrorAsync(ex, "Signing up failed", "HomeViewModel-SignUpAsync");
        }
        return false;
    }

}