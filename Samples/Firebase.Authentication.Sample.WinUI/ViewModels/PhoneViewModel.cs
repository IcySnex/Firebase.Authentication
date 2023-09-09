using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WinUI.Services;
using Firebase.Authentication.Sample.WinUI.Views;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WinUI.Client.Interfaces;

namespace Firebase.Authentication.Sample.WinUI.ViewModels;

public partial class PhoneViewModel : ObservableObject
{
    readonly ILogger<PhoneViewModel> logger;
    readonly WindowHelper windowHelper;
    readonly HomeViewModel homeViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authentication;

    public PhoneViewModel(
        ILogger<PhoneViewModel> logger,
        WindowHelper windowHelper,
        HomeViewModel homeViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.windowHelper = windowHelper;
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
            await windowHelper.AlertErrorAsync("Please first send a verification code.", "Signing in failed", "PhoneViewModel-SignInAsync");
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            await windowHelper.AlertErrorAsync("The verification code field cannot be empty.", "Signing in failed", "PhoneViewModel-SignInAsync");
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
            await windowHelper.AlertErrorAsync("The phone number field cannot be empty.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            await windowHelper.AlertErrorAsync("Please first fill the reCAPTCHA.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
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
            await windowHelper.AlertErrorAsync(ex, "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
        }
    }
}