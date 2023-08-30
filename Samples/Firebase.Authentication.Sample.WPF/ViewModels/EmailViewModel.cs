using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
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
            homeViewModel.ShowSignInError("The email field cannot be empty.");
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            homeViewModel.ShowSignInError("The password field cannot be empty.");
            return;
        }

        if(!await (IsDisplayNameVisible ?
            homeViewModel.SignUpAsync(SignUpRequest.WithEmailPassword(Email, Password, DisplayName)) : 
            homeViewModel.SignInAsync(SignInRequest.WithEmailPassword(Email, Password))))
            return;

        homeViewModel.Navigate<ProviderViewModel>();
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            Provider[]? providers = await authenticaion.GetSignInProvidersAsync(Email);
            if (providers is null)
            {
                IsDisplayNameVisible = true;
                IsPasswordVisible = true;
                return;
            }
            if (providers.Contains(Provider.EmailAndPassword))
            {
                IsPasswordVisible = true;
                return;
            }

            homeViewModel.ShowSignInError("This account only supports signing in via one of these providers: " + string.Join(", ", providers));
        }
        catch (Exception ex)
        {
            homeViewModel.ShowSignInError(ex.Message);
        }
    }


    [RelayCommand]
    async Task ResetPasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            MessageBox.Show("The attempt to reset the password was unsuccessful.\nThe email field can not be empty.", "Resetting password failed!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (MessageBox.Show("If you continue you will get a reset password email sent to your account.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await authenticaion.SendEmailAsync(EmailRequest.ResetPassword(Email));
        }
        catch (Exception ex)
        {
            logger.LogInformation("[EmailViewModel-.ResetPasswordAsync] Resetting password failed: {0}", ex.Message);
            MessageBox.Show("The attempt to reset the password was unsuccessful.\n" + ex.Message, "Resetting password failed!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}