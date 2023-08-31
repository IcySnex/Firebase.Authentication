using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WPF.Client.Interfaces;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class PhoneViewModel : ObservableObject
{
    readonly ILogger<PhoneViewModel> logger;
    readonly HomeViewModel homeViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authenticaion;

    public PhoneViewModel(
        ILogger<PhoneViewModel> logger,
        HomeViewModel homeViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.homeViewModel = homeViewModel;
        this.reCaptcha = reCaptcha;
        this.authenticaion = authenticaion;

        logger.LogInformation("[PhoneViewModel-.ctor] PhoneViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        homeViewModel.Navigate<ProviderViewModel>();


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
            logger.LogErrorAndShow("Please first send a verification code.", "Signing in failed", "PhoneViewModel-SignInAsync");
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            logger.LogErrorAndShow("The verification code field cannot be empty.", "Signing in failed", "PhoneViewModel-SignInAsync");
            return;
        }

        if (await homeViewModel.SignInAsync(SignInRequest.WithPhoneNumber(sessionInfo, Code)))
            homeViewModel.Navigate<ProviderViewModel>();

    }


    [RelayCommand]
    async Task SendCodeAsync()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            logger.LogErrorAndShow("The phone number field cannot be empty.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            logger.LogErrorAndShow("Please first fill the reCAPTCHA.", "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
            return;
        }

        try
        {
            sessionInfo = await authenticaion.SendVerificationCodeAsync(PhoneNumber, ReCaptchaToken!);
            RemoveReCaptchaVerification();

            IsCodeVisible = true;
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Sending verification code failed", "PhoneViewModel-SendCodeAsync");
        }
    }
}