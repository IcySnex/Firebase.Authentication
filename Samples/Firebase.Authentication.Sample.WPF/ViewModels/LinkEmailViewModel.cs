using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class LinkEmailViewModel : ObservableObject
{
    readonly ILogger<LinkEmailViewModel> logger;
    readonly LinkViewModel linkViewModel;
    readonly IAuthenticationClient authenticaion;

    public LinkEmailViewModel(
        ILogger<LinkEmailViewModel> logger,
        LinkViewModel linkViewModel,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.linkViewModel = linkViewModel;
        this.authenticaion = authenticaion;

        logger.LogInformation("[LinkEmailViewModel-.ctor] LinkEmailViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        linkViewModel.Navigate<LinkProviderViewModel>();


    [ObservableProperty]
    bool isPasswordVisible = false;


    [ObservableProperty]
    string email = "";

    [ObservableProperty]
    string password = "";

    [RelayCommand]
    async Task LinkAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            logger.LogErrorAndShow("The email field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync");
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            logger.LogErrorAndShow("The password field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync");
            return;
        }

        if (await linkViewModel.LinkAsync(LinkRequest.ToEmailPassword(Email, Password)))
            linkViewModel.Navigate<LinkProviderViewModel>();
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            SignInMethod method = await authenticaion.GetSignInMethodAsync(Email);
            if (!method.IsRegistered || method.Providers is null)
            {
                IsPasswordVisible = true;
                return;
            }
            if (!method.Providers.Contains(Provider.EmailAndPassword))
            {
                IsPasswordVisible = true;
                return;
            }

            logger.LogErrorAndShow("An user with this email already exists.", "Linking failed", "LinkEmailViewModel-PrepareSignInAsync");
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Linking failed", "LinkEmailViewModel-PrepareSignInAsync");
        }
    }
}