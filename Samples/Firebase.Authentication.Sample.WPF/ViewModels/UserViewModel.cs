using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Firebase.Authentication.Sample.WPF.Services;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class UserViewModel : ObservableObject
{
    readonly ILogger<UserViewModel> logger;
    readonly MainViewModel mainViewModel;
    readonly ImageUploader imageUploader;

    public IAuthenticationClient Authentication { get; }

    public UserViewModel(
        ILogger<UserViewModel> logger,
        MainViewModel mainViewModel,
        ImageUploader imageUploader,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.mainViewModel = mainViewModel;
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
                IsAddSignInMethodVisible = UsedSignInMethods is null ? true : Enum.GetValues<Provider>().Except(UsedSignInMethods).Any();
                break;
        }
    }


    [RelayCommand]
    async Task UploadAvatarAsync()
    {
        try
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Image Files|*.jpg;*.png;*.jpeg;*.gif",
                Title = "Please select your avatar!",
                CheckFileExists = true,
                CheckPathExists = true
            };
            if (fileDialog.ShowDialog() is not bool fileDialogResult || !fileDialogResult)
                return;

            string photoUrl = await imageUploader.UploadAsync(fileDialog.FileName, "avatar");
            await Authentication.UpdateAsync(null, photoUrl);
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Uploading avatar failed", "UserViewModel-UploadAvatarAsync");
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
            logger.LogErrorAndShow(ex, "Removing avatar failed", "UserViewModel-UploadAvatarAsync");
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
            logger.LogErrorAndShow(ex, "Changing display name failed", "UserViewModel-OnIsEditDisplayNameChanged");
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

        if (MessageBox.Show("If you continue you wont be able to use your old email to sign in anymore.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
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
            logger.LogErrorAndShow(ex, "Changing email failed", "UserViewModel-OnIsEmailChangeableChanged");
        }
    }

    async Task RemoveEmailAsync()
    {
        if (MessageBox.Show("If you continue you will no longer be able to sign in via your email address. This also includes signing in via email and password.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await Authentication.ChangeEmailAsync(null);
        }

        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Removing email address failed", "UserViewModel-RemoveEmailAsync");
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
            logger.LogInformationAndShow("A 'verify email address' mail has been sent to your account! Please check your inbox.", "Sent email", "UserViewModel-VerifyEmailAsync");
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Verifying email failed", "UserViewModel-VerifyEmailAsync");
        }
    }


    [RelayCommand]
    void ChangePassword() =>
        mainViewModel.ShowModal<ChangePasswordViewModel>();


    [ObservableProperty]
    Provider[]? usedSignInMethods;

    [ObservableProperty]
    bool isAddSignInMethodVisible = true;

    [RelayCommand]
    void AddSignInMethod() =>
        mainViewModel.ShowModal<LinkViewModel>();

    [RelayCommand]
    async Task RemoveSignInMethodAsync(
        Provider provider)
    {
        if (provider == Provider.EmailLink)
        {
            await RemoveEmailAsync();
            return;
        }

        if (MessageBox.Show("If you continue you will no longer be able to use this method to sign in.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await Authentication.UnlinkAsync(provider);
        }

        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Removing sign-in method failed", "UserViewModel-RemoveSignInMethodAsync");
        }
    }


    [RelayCommand]
    async Task RefreshAsync()
    {
        try
        {
            await Authentication.GetFreshUserAsync(TimeSpan.FromHours(1), true);
            logger.LogInformationAndShow("The user info successfully refreshed", "Refreshed user info", "UserViewModel-RefreshAsync");
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Refreshing user info failed", "UserViewModel-RefreshAsync");
        }
    }

    [RelayCommand]
    void SignOut()
    {
        Authentication.SignOut();
        mainViewModel.Navigate<HomeViewModel>();
    }

    [RelayCommand]
    async Task DeleteAsync()
    {
        if (MessageBox.Show("Deleting your account cannot be undone and will result in the permanent loss of all your data.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await Authentication.DeleteAsync();

            mainViewModel.Navigate<HomeViewModel>();
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Deleting user failed", "UserViewModel-DeleteAsync");
        }
    }
}