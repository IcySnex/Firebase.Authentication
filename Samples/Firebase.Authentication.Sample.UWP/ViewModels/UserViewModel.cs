#nullable enable

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
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class UserViewModel : ObservableObject
{
    readonly ILogger<UserViewModel> logger;
    readonly LinkViewModel linkViewModel;
    readonly Navigation navigation;
    readonly ImageUploader imageUploader;

    public IAuthenticationClient Authentication { get; }

    public UserViewModel(
        ILogger<UserViewModel> logger,
        LinkViewModel linkViewModel,
        Navigation navigation,
        ImageUploader imageUploader,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.linkViewModel = linkViewModel;
        this.navigation = navigation;
        this.imageUploader = imageUploader;

        this.Authentication = authentication;

        Authentication.PropertyChanged += OnAuthenticationPropertyChanged;
        OnAuthenticationPropertyChanged(null, new PropertyChangedEventArgs<UserInfo>("CurrentUser", null, Authentication.CurrentUser));

        logger.LogInformation("[UserViewModel-.ctor] UserViewModel has been initialized.");
    }

    void OnAuthenticationPropertyChanged(object? _, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e)
        {
            case PropertyChangedEventArgs<UserInfo> args:
                DisplayName = args.NewValue?.DisplayName ?? null;

                Email = args.NewValue?.Email ?? null;

                IsVerifyEmailVisible = !(args.NewValue?.IsEmailVerified ?? true) && !string.IsNullOrWhiteSpace(args.NewValue?.Email);

                UsedSignInMethods = args.NewValue?.ProviderUserInfos?.Select(info => info.Provider).ToArray() ?? null;
                IsAddSignInMethodVisible = UsedSignInMethods is null ? true : ((Provider[])Enum.GetValues(typeof(Provider))).Except(UsedSignInMethods).Any();
                break;
        }
    }


    void NavigateToHome()
    {
        navigation.NavigateSilent("Home");
        navigation.SetNavigationViewItemVisibility(0, true);
        navigation.SetNavigationViewItemVisibility(1, false);
    }


    [RelayCommand]
    async Task UploadAvatarAsync()
    {
        try
        {
            FileOpenPicker picker = new()
            {
                ViewMode = PickerViewMode.Thumbnail,
                CommitButtonText = "Upload",
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".gif");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file is null)
                return;

            string photoUrl = await imageUploader.UploadAsync(file, "avatar");
            await Authentication.UpdateAsync(null, photoUrl);
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Uploading avatar failed", "UserViewModel-UploadAvatarAsync", logger);
        }
    }

    [RelayCommand]
    async Task RemoveAvatarAsync()
    {
        try
        {
            await Authentication.UpdateAsync(null, null, deletePhotoUrl: true);
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Removing avatar failed", "UserViewModel-UploadAvatarAsync", logger);
        }
    }


    [ObservableProperty]
    bool isDisplayNameChangeable = false;

    private string? displayName;
    public string? DisplayName
    {
        get => displayName;
        set => SetProperty(ref displayName, string.IsNullOrWhiteSpace(value) ? null : value);
    }

    async partial void OnIsDisplayNameChangeableChanged(bool value)
    {
        if (value)
            return;

        UserInfo user = await Authentication.GetFreshUserAsync(TimeSpan.FromHours(1));
        if (user.DisplayName == DisplayName)
            return;

        try
        {
            await Authentication.UpdateAsync(DisplayName, null, deleteDisplayName: DisplayName is null);
        }
        catch (Exception ex)
        {
            DisplayName = user.DisplayName;
            await Extensions.AlertErrorAsync(ex, "Changing display name failed", "UserViewModel-OnIsEditDisplayNameChanged", logger);
        }
    }


    [ObservableProperty]
    bool isEmailChangeable = false;

    private string? email;
    public string? Email
    {
        get => email;
        set => SetProperty(ref email, string.IsNullOrWhiteSpace(value) ? null : value);
    }

    async partial void OnIsEmailChangeableChanged(bool value)
    {
        if (value)
            return;

        UserInfo user = await Authentication.GetFreshUserAsync(TimeSpan.FromHours(1));
        if (user.Email == Email)
            return;

        if (string.IsNullOrWhiteSpace(Email))
        {
            await RemoveEmailAsync();
            return;
        }

        if ((await Extensions.AlertAsync("If you continue you wont be able to use your old email to sign in anymore.\nDo you want to continue?", "Are you sure?", "No", "Yes")).Label != "Yes")
        {
            Email = user.Email;
            return;
        }

        try
        {
            await Authentication.ChangeEmailAsync(Email);
        }
        catch (Exception ex)
        {
            Email = user.Email;
            await Extensions.AlertErrorAsync(ex, "Changing email failed", "UserViewModel-OnIsEmailChangeableChanged", logger);
        }
    }

    async Task RemoveEmailAsync()
    {
        if ((await Extensions.AlertAsync("If you continue you will no longer be able to sign in via your email address. This also includes signing in via email and password.\nDo you want to continue?", "Are you sure?", "No", "Yes")).Label != "Yes")
            return;

        try
        {
            await Authentication.ChangeEmailAsync(null);
            await Authentication.UnlinkAsync(Provider.EmailAndPassword);
        }

        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Removing email address failed", "UserViewModel-RemoveEmailAsync", logger);
        }
    }


    [ObservableProperty]
    bool isVerifyEmailVisible = true;

    [RelayCommand]
    void CloseVerifyEmail() =>
        IsVerifyEmailVisible = false;

    [RelayCommand]
    async Task VerifyEmailAsync()
    {
        try
        {
            await Authentication.SendEmailAsync(EmailRequest.Verify(), "en");
            IsVerifyEmailVisible = false;
            await Extensions.AlertAsync("A 'verify email address' mail has been sent to your account! Please check your inbox.", "Sent email");
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Verifying email failed", "UserViewModel-VerifyEmailAsync", logger);
        }
    }


    [RelayCommand]
    async Task ChangePasswordAsync()
    {
        ChangePasswordView view = new();

        if (await Extensions.ShowDialogAsync(view, null, "Cancel", "Continue") != ContentDialogResult.Primary)
            return;

        if (string.IsNullOrWhiteSpace(view.CurrentPasswordBox.Password) || string.IsNullOrWhiteSpace(view.NewPasswordBox.Password) || string.IsNullOrWhiteSpace(view.ConfirmNewPasswordBox.Password))
        {
            await Extensions.AlertErrorAsync("The current, new and confirm new password field can not be empty.", "Changing password failed", "ChangePasswordViewModel-ContinueAsync", logger);
            return;
        }
        if (view.NewPasswordBox.Password != view.ConfirmNewPasswordBox.Password)
        {
            await Extensions.AlertErrorAsync("The new password does not match the confirm new password.", "Changing password failed", "ChangePasswordViewModel-ContinueAsync", logger);
            return;
        }

        try
        {
            await Authentication.ChangePasswordAsync(view.NewPasswordBox.Password, view.CurrentPasswordBox.Password);
            Authentication.SignOut();

            NavigateToHome();
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Changing password failed", "ChangePasswordViewModel-ContinueAsync", logger);
        }
    }


    [ObservableProperty]
    Provider[]? usedSignInMethods;


    [ObservableProperty]
    bool isAddSignInMethodVisible = true;

    [RelayCommand]
    async Task AddSignInMethodAsync()
    {
        linkViewModel.NavigateToProvider();
        await Extensions.ShowDialogAsync(linkViewModel.Dialog);
    }

    [RelayCommand]
    async Task RemoveSignInMethodAsync(
        Provider provider)
    {
        if (provider == Provider.EmailLink)
        {
            await RemoveEmailAsync();
            return;
        }

        if ((await Extensions.AlertAsync("If you continue you will no longer be able to use this method to sign in.\nDo you want to continue?", "Are you sure?", "No", "Yes")).Label != "Yes")
            return;

        try
        {
            await Authentication.UnlinkAsync(provider);
        }

        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Removing sign-in method failed", "UserViewModel-RemoveSignInMethodAsync", logger);
        }
    }


    [RelayCommand]
    async Task RefreshAsync()
    {
        try
        {
            await Authentication.GetFreshUserAsync(TimeSpan.FromHours(1), true);
            await Extensions.AlertAsync("The user info successfully refreshed", "Refreshed user info");
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Refreshing user info failed", "UserViewModel-RefreshAsync", logger);
        }
    }

    [RelayCommand]
    void SignOut()
    {
        Authentication.SignOut();

        NavigateToHome();
    }

    [RelayCommand]
    async Task DeleteAsync()
    {
        if ((await Extensions.AlertAsync("Deleting your account cannot be undone and will result in the permanent loss of all your data.\nDo you want to continue?", "Are you sure?", "No", "Yes")).Label != "Yes")
            return;

        try
        {
            await Authentication.DeleteAsync();

            NavigateToHome();
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Deleting user failed", "UserViewModel-DeleteAsync", logger);
        }
    }
}