using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class ChangePasswordViewModel : ObservableObject
{
    readonly ILogger<ChangePasswordViewModel> logger;
    readonly MainViewModel mainViewModel;
    readonly IAuthenticationClient authenticaion;

    public ChangePasswordViewModel(
        ILogger<ChangePasswordViewModel> logger,
        MainViewModel mainViewModel,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.mainViewModel = mainViewModel;
        this.authenticaion = authenticaion;
    }


    [ObservableProperty]
    string currentPassword = string.Empty;

    [ObservableProperty]
    string newPassword = string.Empty;

    [ObservableProperty]
    string confirmNewPassword = string.Empty;


    [RelayCommand]
    void Cancel()
    {
        mainViewModel.CloseModal();
    }

    [RelayCommand]
    async Task ContinueAsync()
    {
        if (string.IsNullOrWhiteSpace(CurrentPassword) || string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(ConfirmNewPassword))
        {
            ShowError("The current, new and confirm new password field can not be empty!");
            return;
        }
        if (NewPassword != ConfirmNewPassword)
        {
            ShowError("The new password does not match the confirm new password!");
            return;
        }

        try
        {
            await authenticaion.ChangePasswordAsync(NewPassword, CurrentPassword);
            authenticaion.SignOut();
            mainViewModel.CloseModal();
            mainViewModel.Navigate<HomeViewModel>();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    void ShowError(
        string message)
    {
        logger.LogError("[UserViewModel-.VerifyEmailAsync] Verifying email failed: {0}", message);
        MessageBox.Show("The attempt to change the password was unsuccessful.\n" + message, "Changing password failed!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}