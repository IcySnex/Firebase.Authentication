using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Firebase.Authentication.Sample.WPF.Services;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.UI;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class UserViewModel : ObservableObject
{
    readonly ILogger<UserViewModel> logger;
    readonly MainViewModel mainViewModel;
    readonly ImageUploader imageUploader;

    public IAuthenticationClient Authenticaion { get; }

    public UserViewModel(
        ILogger<UserViewModel> logger,
        MainViewModel mainViewModel,
        ImageUploader imageUploader,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.mainViewModel = mainViewModel;
        this.imageUploader = imageUploader;

        Authenticaion = authenticaion;
        Authenticaion.PropertyChanged += OnAuthenticaionPropertyChanged;
        OnAuthenticaionPropertyChanged(null, new PropertyChangedEventArgs<UserInfo>("CurrentUser", null, Authenticaion.CurrentUser));

        logger.LogInformation("[UserViewModel-.ctor] UserViewModel has been initialized.");
    }

    void OnAuthenticaionPropertyChanged(object? _, System.ComponentModel.PropertyChangedEventArgs args)
    {
        switch (args.PropertyName)
        {
            case "CurrentUser":
                PropertyChangedEventArgs<UserInfo> e = (PropertyChangedEventArgs<UserInfo>)args;

                DisplayName = e.NewValue?.DisplayName ?? null;

                Email = e.NewValue?.Email ?? null;

                IsVerifyEmailVisible = !(e.NewValue?.IsEmailVerified ?? true) && !string.IsNullOrWhiteSpace(e.NewValue?.Email);

                UsedSignInMethods = e.NewValue?.ProviderUserInfos?.Select(info => info.Provider).ToArray() ?? null;
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
            bool? showFileDialog = fileDialog.ShowDialog();

            if (!showFileDialog.HasValue || !showFileDialog.Value)
                return;

            string imagePath = fileDialog.FileName;
            string photoUrl = await imageUploader.UploadAsync(imagePath, "avatar");

            await Authenticaion.UpdateAsync(null, photoUrl);
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
            await Authenticaion.UpdateAsync(null, null, deletePhotoUrl: true);
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Removing avatar failed", "UserViewModel-UploadAvatarAsync");
        }
    }


    [ObservableProperty]
    bool isDisplayNameChangeable = false;

    async partial void OnIsDisplayNameChangeableChanged(bool value)
    {
        UserInfo user = await Authenticaion.GetFreshUserAsync(TimeSpan.FromHours(1));
        if (value || user.DisplayName == DisplayName)
            return;

        try
        {
            await Authenticaion.UpdateAsync(DisplayName, null, deleteDisplayName: DisplayName is null);
        }
        catch (Exception ex)
        {
            DisplayName = user.DisplayName;
            logger.LogErrorAndShow(ex, "Changing display name failed", "UserViewModel-OnIsEditDisplayNameChanged");
        }
    }

    private string? displayName;
    public string? DisplayName
    {
        get => displayName;
        set => SetProperty(ref displayName, string.IsNullOrWhiteSpace(value) ? null : value);
    }
    

    [ObservableProperty]
    bool isEmailChangeable = false;

    async partial void OnIsEmailChangeableChanged(bool value)
    {
        UserInfo user = await Authenticaion.GetFreshUserAsync(TimeSpan.FromHours(1));
        if (value || user.Email == Email)
            return;

        if (string.IsNullOrWhiteSpace(Email))
        {
            await RemoveEmailAsync();
            return;
        }

        if (MessageBox.Show("If you continue you wont be able to use your old email to sign in anymore. If you press 'Yes' you will get signed out\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
        {
            Email = user.Email;
            return;
        }

        try
        {
            await Authenticaion.ChangeEmailAsync(Email);

            Authenticaion.SignOut();
            mainViewModel.Navigate<HomeViewModel>();
        }
        catch (Exception ex)
        {
            Email = user.Email;
            logger.LogErrorAndShow(ex, "Changing email failed", "UserViewModel-OnIsEmailChangeableChanged");
        }
    }

    private string? email;
    public string? Email
    {
        get => email;
        set => SetProperty(ref email, string.IsNullOrWhiteSpace(value) ? null : value);
    }

    async Task RemoveEmailAsync()
    {
        if (MessageBox.Show("If you continue you will no longer be able to sign in via your email address. This also includes signing in via email and password.\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            await Authenticaion.ChangeEmailAsync(null);
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
            await Authenticaion.SendEmailAsync(EmailRequest.Verify(), "en");
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
            await Authenticaion.UnlinkAsync(provider);
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
            await Authenticaion.GetFreshUserAsync(TimeSpan.FromHours(1), true);
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
        Authenticaion.SignOut();
        mainViewModel.Navigate<HomeViewModel>();
    }

    [RelayCommand]
    void Delete()
    {
        logger.LogInformation("Delete");
    }
}