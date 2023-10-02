using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WinUI.Services;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WinUI.ViewModels;

public partial class LinkEmailViewModel : ObservableObject
{
    readonly WindowHelper windowHelper;
    readonly IAuthenticationClient authentication;

    public LinkViewModel LinkViewModel = default!;

    public LinkEmailViewModel(
        ILogger<LinkEmailViewModel> logger,
        WindowHelper windowHelper,
        IAuthenticationClient authentication)
    {
        this.windowHelper = windowHelper;
        this.authentication = authentication;

        logger.LogInformation("[LinkEmailViewModel-.ctor] LinkEmailViewModel has been initialized.");
    }


    [ObservableProperty]
    bool isPasswordVisible = false;


    [ObservableProperty]
    string email = "";
    [ObservableProperty]
    string password = "";

    [RelayCommand]
    public async Task LinkAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await windowHelper.AlertErrorAsync("The email field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync");
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            await windowHelper.AlertErrorAsync("The password field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync");
            return;
        }

        await LinkViewModel.LinkAsync(LinkRequest.ToEmailPassword(Email, Password));
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            SignInMethod method = await authentication.GetSignInMethodAsync(Email);
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

            await windowHelper.AlertErrorAsync("An user with this email already exists.", "Linking failed", "LinkEmailViewModel-PrepareSignInAsync");
        }
        catch (Exception ex)
        {
            await windowHelper.AlertErrorAsync(ex, "Linking failed", "LinkEmailViewModel-PrepareSignInAsync");
        }
    }
}