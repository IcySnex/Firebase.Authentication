using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Helpers;
using Firebase.Authentication.Sample.UWP.Services;
using Firebase.Authentication.Sample.UWP.Views;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.UWP.Client.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class PhoneViewModel : ObservableObject
{
    readonly ILogger<PhoneViewModel> logger;
    readonly HomeViewModel homeViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authentication;

    public PhoneViewModel(
        ILogger<PhoneViewModel> logger,
        HomeViewModel homeViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.homeViewModel = homeViewModel;
        this.reCaptcha = reCaptcha;
        this.authentication = authentication;

        logger.LogInformation("[PhoneViewModel-.ctor] PhoneViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate(new ProviderView());


    [ObservableProperty]
    bool isCodeVisible = false;

    string? sessionInfo;


    [ObservableProperty]
    string phoneNumber = "";

    [ObservableProperty]
    string code = "";


    [ObservableProperty]
    string? reCaptchaToken;

    [ObservableProperty]
    bool isReCaptchaChecked = false;

    [ObservableProperty]
    bool isReCaptchaLoading = false;

    [ObservableProperty]
    string? reCaptchaErrorMessage = null;

    CancellationTokenSource? reCaptchaCancelSource = null;


    [RelayCommand]
    async Task VerifyReCaptchaAsync()
    {
        ReCaptchaErrorMessage = null;
        IsReCaptchaLoading = true;

        try
        {
            reCaptchaCancelSource = new(TimeSpan.FromMinutes(1));
            ReCaptchaToken = await reCaptcha.VerifyAsync(reCaptchaCancelSource.Token);
        }
        catch (TaskCanceledException)
        {
            ReCaptchaToken = null;
            IsReCaptchaChecked = false;
        }
        catch (Exception ex)
        {
            ReCaptchaToken = null;
            IsReCaptchaChecked = false;
            ReCaptchaErrorMessage = ex.Message;
        }
        finally
        {
            IsReCaptchaLoading = false;
            reCaptchaCancelSource = null;
        }
    }

    [RelayCommand]
    void RemoveReCaptchaVerification()
    {
        ReCaptchaToken = null;
        IsReCaptchaChecked = false;
        reCaptchaCancelSource?.Cancel();
    }


    [RelayCommand]
    async Task SignInAsync()
    {
        if (sessionInfo is null)
        {
            await Extensions.AlertErrorAsync("Please first send a verification code.", "Signing in failed", "PhoneViewModel-SignInAsync", logger);
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            await Extensions.AlertErrorAsync("The verification code field cannot be empty.", "Signing in failed", "PhoneViewModel-SignInAsync", logger);
            return;
        }

        if (await homeViewModel.SignInAsync(SignInRequest.WithPhoneNumber(sessionInfo, Code)))
            homeViewModel.Navigate(new ProviderView());

    }


    [RelayCommand]
    async Task SendCodeAsync()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            await Extensions.AlertErrorAsync("The phone number field cannot be empty.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync", logger);
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            await Extensions.AlertErrorAsync("Please first fill the reCAPTCHA.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync", logger);
            return;
        }

        try
        {
            sessionInfo = await authentication.SendVerificationCodeAsync(PhoneNumber, ReCaptchaToken!);
            RemoveReCaptchaVerification();

            IsCodeVisible = true;
        }
        catch (Exception ex)
        {
            await Extensions.AlertErrorAsync(ex, "Sending verification code failed", "PhoneViewModel-SendCodeAsync", logger);
        }
    }
}