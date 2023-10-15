using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Helpers;
using Firebase.Authentication.Sample.UWP.Services;
using Firebase.Authentication.Sample.UWP.Views;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class EmailViewModel : ObservableObject
{
    readonly ILogger<EmailViewModel> logger;
    readonly HomeViewModel homeViewModel;
    readonly IAuthenticationClient authentication;

    public EmailViewModel(
        ILogger<EmailViewModel> logger,
        HomeViewModel homeViewModel,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.homeViewModel = homeViewModel;
        this.authentication = authentication;

        logger.LogInformation("[EmailViewModel-.ctor] EmailViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate(new ProviderView());


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsResetPasswordVisible))]
    bool isDisplayNameVisible = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsResetPasswordVisible))]
    bool isPasswordVisible = false;

    public bool IsResetPasswordVisible => !IsDisplayNameVisible && IsPasswordVisible;


    [ObservableProperty]
    string email = "";

    [ObservableProperty]
    string? displayName;

    [ObservableProperty]
    string password = "";

    [RelayCommand]
    async Task SignInAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await Extensions.AlertErrorAsync("The email field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync", logger);
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            await Extensions.AlertErrorAsync("The password field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync", logger);
            return;
        }

        if (await (IsDisplayNameVisible ?
            homeViewModel.SignUpAsync(SignUpRequest.WithEmailPassword(Email, Password, string.IsNullOrWhiteSpace(DisplayName) ? null : DisplayName)) :
            homeViewModel.SignInAsync(SignInRequest.WithEmailPassword(Email, Password))))
            homeViewModel.Navigate(new ProviderView());
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            SignInMethod method = await authentication.GetSignInMethodAsync(Email);
            if (!method.IsRegistered)
            {
                IsDisplayNameVisible = true;
                IsPasswordVisible = true;
                return;
            }
            if (method.Providers is null)
            {
                await Extensions.AlertErrorAsync("This account only supports signing in via an email link, which is not supported by this application.", "Signing up failed", "EmailViewModel-PrepareSignInAsync", logger);
                return;
            }
            if (method.Providers.Contains(Provider.EmailAndPassword))
            {
                IsPasswordVisible = true;
                return;
            }

            await Extensions.AlertErrorAsync("This account only supports signing in via one of these providers: " + string.Join(", ", method.Providers), "Signing up failed", "EmailViewModel-PrepareSignInAsync", logger);
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Signing up failed", "EmailViewModel-PrepareSignInAsync", logger);
        }
    }


    [RelayCommand]
    async Task ResetPasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await Extensions.AlertErrorAsync("The email field can not be empty", "Resetting password failed", "EmailViewModel-ResetPasswordAsync", logger);
            return;
        }

        if ((await Extensions.AlertAsync("If you continue a 'reset password' mail will be sent to your account and all of your linked sign-in methods will be removed.\nDo you want to continue?", "Are you sure?", "No", "Yes")).Label != "Yes")
            return;

        try
        {
            await authentication.SendEmailAsync(EmailRequest.ResetPassword(Email));
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Resetting password failed", "EmailViewModel-ResetPasswordAsync", logger);
        }
    }
}