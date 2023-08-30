using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
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
                IsVerifyEmailVisible = !e.NewValue?.IsEmailVerified ?? true && !string.IsNullOrWhiteSpace(e.NewValue?.Email);
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
            logger.LogInformation("[UserViewModel-.UploadAvatarAsync] Uploading avatar failed: {0}", ex.Message);
            MessageBox.Show("The attempt to upload an avatar was unsuccessful.\n" + ex.Message, "Avatar upload failed!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            logger.LogInformation("[UserViewModel-.RemoveAvatarAsync] Removing avatar failed: {0}", ex.Message);
            MessageBox.Show("The attempt to remove the avatar was unsuccessful.\n" + ex.Message, "Avatar remove failed!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


    [ObservableProperty]
    bool isEditDisplayName = false;

    async partial void OnIsEditDisplayNameChanged(bool value)
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
            logger.LogInformation("[UserViewModel-.OnIsEditDisplayNameChanged] Editing display name failed: {0}", ex.Message);
            MessageBox.Show("The attempt to edit the display name was unsuccessful.\n" + ex.Message, "Editing display name failed!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private string? displayName;
    public string? DisplayName
    {
        get => displayName;
        set => SetProperty(ref displayName, string.IsNullOrWhiteSpace(value) ? null : value);
    }
    

    [ObservableProperty]
    bool isEditEmail = false;

    async partial void OnIsEditEmailChanged(bool value)
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
            logger.LogInformation("[UserViewModel-.OnIsEditEmailChanged] Editing email failed: {0}", ex.Message);
            MessageBox.Show("The attempt to change the email was unsuccessful.\n" + ex.Message, "Editing email name failed!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            MessageBox.Show("A verify email was successfully sent to your account. Please check your email inbox!", "Verify email sent!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            logger.LogInformation("[UserViewModel-.VerifyEmailAsync] Verifying email failed: {0}", ex.Message);
            MessageBox.Show("The attempt to send an verify email was unsuccessful.\n" + ex.Message, "Verifying email failed!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


    [RelayCommand]
    async Task RefreshAsync()
    {
        try
        {
            await Authenticaion.GetFreshUserAsync(TimeSpan.FromHours(1), true);
            MessageBox.Show("The user info successfully refreshed!", "Refreshed user info!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            logger.LogInformation("[UserViewModel-.RefreshAsync] Refreshing user info failed: {0}", ex.Message);
            MessageBox.Show("The attempt to refresh the user info was unsuccessful.\n" + ex.Message, "Refreshing user info failed!", MessageBoxButton.OK, MessageBoxImage.Error);
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