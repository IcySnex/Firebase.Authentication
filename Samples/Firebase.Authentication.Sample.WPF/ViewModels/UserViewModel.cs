using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
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

                DisplayName = e.NewValue?.DisplayName ?? "";
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
        try
        {
            if (value || (await Authenticaion.GetFreshUserAsync()).DisplayName == DisplayName)
                return;

            await Authenticaion.UpdateAsync(DisplayName, null, deleteDisplayName: DisplayName is null);
        }
        catch (Exception ex)
        {
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