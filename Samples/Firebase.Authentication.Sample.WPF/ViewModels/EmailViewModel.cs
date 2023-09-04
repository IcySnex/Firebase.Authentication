using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class EmailViewModel : ObservableObject
{
    readonly ILogger<EmailViewModel> logger;
    readonly HomeViewModel homeViewModel;
    readonly IAuthenticationClient authenticaion;

    public EmailViewModel(
        ILogger<EmailViewModel> logger,
        HomeViewModel homeViewModel,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.homeViewModel = homeViewModel;
        this.authenticaion = authenticaion;

        logger.LogInformation("[EmailViewModel-.ctor] EmailViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate<ProviderViewModel>();


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
            logger.LogErrorAndShow("The email field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync");
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            logger.LogErrorAndShow("The password field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync");
            return;
        }

        if (await (IsDisplayNameVisible ?
            homeViewModel.SignUpAsync(SignUpRequest.WithEmailPassword(Email, Password, DisplayName)) :
            homeViewModel.SignInAsync(SignInRequest.WithEmailPassword(Email, Password))))
            homeViewModel.Navigate<ProviderViewModel>();
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            SignInMethod method = await authenticaion.GetSignInMethodAsync(Email);
            if (!method.IsRegistered)
            {
                IsDisplayNameVisible = true;
                IsPasswordVisible = true;
                return;
            }
            if (method.Providers is null)
            {
                logger.LogErrorAndShow("This account only supports signing in via an email link, which is not supported by this application.", "Signing up failed", "EmailViewModel-PrepareSignInAsync");
                return;
            }
            if (method.Providers.Contains(Provider.EmailAndPassword))
            {
                IsPasswordVisible = true;
                return;
            }

            logger.LogErrorAndShow("This account only supports signing in via one of these providers: " + string.Join(", ", method.Providers), "Signing up failed", "EmailViewModel-PrepareSignInAsync");
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing up failed", "EmailViewModel-PrepareSignInAsync");
        }
    }


    [RelayCommand]
    async Task ResetPasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            logger.LogErrorAndShow("The email field can not be empty", "Resetting password failed", "EmailViewModel-ResetPasswordAsync");
            return;
        }

        if (MessageBox.Show("If you continue a 'reset password' mail will be sent to your account and all of your linked sign-in methods will be removed.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await authenticaion.SendEmailAsync(EmailRequest.ResetPassword(Email));
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Resetting password failed", "EmailViewModel-ResetPasswordAsync");
        }
    }
}