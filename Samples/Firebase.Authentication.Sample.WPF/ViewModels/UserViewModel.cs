using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Firebase.Authentication.Sample.WPF.Services;
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
            MessageBox.Show("The attempt to change the email was unsuccessful.\nThe email field can not be empty.", "Editing email failed!", MessageBoxButton.OK, MessageBoxImage.Error);
            Email = user.Email;
            return;
        }

        if (MessageBox.Show("If you continue you will get a change email sent to your account. Once verified you will be able to use your new email. If you press 'Yes' you will get signed out!\nDo you want to continue?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
        {
            Email = user.Email;
            return;
        }

        try
        {
            await Authenticaion.SendEmailAsync(EmailRequest.Change(Email));
            SignOut();
        }
        catch (Exception ex)
        {
            Email = user.Email;
            logger.LogErrorAndShow(ex, "Changing email failed", "UserViewModel-OnIsEditEmailChanged");
        }
    }

    private string? email;
    public string? Email
    {
        get => email;
        set => SetProperty(ref email, string.IsNullOrWhiteSpace(value) ? null : value);
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