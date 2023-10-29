#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Helpers;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class LinkEmailViewModel : ObservableObject
{
    readonly ILogger<LinkEmailViewModel> logger;
    readonly IAuthenticationClient authentication;

    public LinkViewModel LinkViewModel = default!;

    public LinkEmailViewModel(
        ILogger<LinkEmailViewModel> logger,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
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
            await Extensions.AlertErrorAsync("The email field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync", logger);
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            await Extensions.AlertErrorAsync("The password field cannot be empty.", "Linking failed", "LinkEmailViewModel-LinkAsync", logger);
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

            await Extensions.AlertErrorAsync("An user with this email already exists.", "Linking failed", "LinkEmailViewModel-PrepareSignInAsync", logger);
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Linking failed", "LinkEmailViewModel-PrepareSignInAsync", logger);
        }
    }
}