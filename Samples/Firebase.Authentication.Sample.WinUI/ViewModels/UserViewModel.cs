using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Sample.WinUI.Services;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WinUI.ViewModels;

public class UserViewModel
{
    readonly ILogger<UserViewModel> logger;
    readonly Navigation navigation;
    readonly ImageUploader imageUploader;

    public IAuthenticationClient Authentication { get; }

    public UserViewModel(
        ILogger<UserViewModel> logger,
        Navigation navigation,
        ImageUploader imageUploader,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
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
                //DisplayName = args.NewValue?.DisplayName ?? null;

                //Email = args.NewValue?.Email ?? null;

                //IsVerifyEmailVisible = !(args.NewValue?.IsEmailVerified ?? true) && !string.IsNullOrWhiteSpace(args.NewValue?.Email);

                //UsedSignInMethods = args.NewValue?.ProviderUserInfos?.Select(info => info.Provider).ToArray() ?? null;
                //IsAddSignInMethodVisible = UsedSignInMethods is null ? true : Enum.GetValues<Provider>().Except(UsedSignInMethods).Any();
                break;
        }
    }
}