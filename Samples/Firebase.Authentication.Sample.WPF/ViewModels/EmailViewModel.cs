using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class EmailViewModel : ObservableObject
{
    readonly HomeViewModel homeViewModel;
    readonly IAuthenticationClient authenticaion;

    public EmailViewModel(
        ILogger<EmailViewModel> logger,
        HomeViewModel homeViewModel,
        IAuthenticationClient authenticaion)
    {
        this.homeViewModel = homeViewModel;
        this.authenticaion = authenticaion;

        logger.LogInformation("[EmailViewModel-.ctor] EmailViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate<ProviderViewModel>();


    [ObservableProperty]
    bool isDisplayNameVisible = false;

    [ObservableProperty]
    bool isPasswordVisible = false;


    [ObservableProperty]
    string email;

    [ObservableProperty]
    string displayName;

    [ObservableProperty]
    string password;

    [RelayCommand]
    async Task SignInAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            homeViewModel.ShowSignInError("The email field cannot be empty.");
            return;
        }
        if (!IsPasswordVisible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            homeViewModel.ShowSignInError("The password field cannot be empty.");
            return;
        }

        if(!await (IsDisplayNameVisible ?
            homeViewModel.SignUpAsync(SignUpRequest.WithEmailPassword(Email, Password, DisplayName)) : 
            homeViewModel.SignInAsync(SignInRequest.WithEmailPassword(Email, Password))))
            return;

        homeViewModel.Navigate<ProviderViewModel>();
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            Provider[]? providers = await authenticaion.GetSignInProvidersAsync(Email);
            if (providers is null)
            {
                IsDisplayNameVisible = true;
                IsPasswordVisible = true;
                return;
            }
            if (providers.Contains(Provider.EmailAndPassword))
            {
                IsPasswordVisible = true;
                return;
            }

            homeViewModel.ShowSignInError("This account only supports signing in via one of these providers: " + string.Join(", ", providers));
        }
        catch (Exception ex)
        {
            homeViewModel.ShowSignInError(ex.Message);
        }
    }
}