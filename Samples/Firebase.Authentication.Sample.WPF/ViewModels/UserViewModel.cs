using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Sample.WPF.Services;
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

        logger.LogInformation("[UserViewModel-.ctor] UserViewModel has been initialized.");
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