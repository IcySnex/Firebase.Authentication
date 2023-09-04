using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Sample.WPF.Helpers;
using Microsoft.Extensions.Logging;

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
            logger.LogErrorAndShow("The current, new and confirm new password field can not be empty.", "Changing password failed", "ChangePasswordViewModel-ContinueAsync");
            return;
        }
        if (NewPassword != ConfirmNewPassword)
        {
            logger.LogErrorAndShow("The new password does not match the confirm new password.", "Changing password failed", "ChangePasswordViewModel-ContinueAsync");
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
            logger.LogErrorAndShow(ex, "Changing password failed", "ChangePasswordViewModel-ContinueAsync");
        }
    }
}