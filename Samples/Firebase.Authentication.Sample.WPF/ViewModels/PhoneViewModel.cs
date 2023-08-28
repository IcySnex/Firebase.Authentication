using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WPF.Client;
using ReCaptcha.Desktop.WPF.Client.Interfaces;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class PhoneViewModel : ObservableObject
{
    readonly HomeViewModel homeViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authenticaion;

    public PhoneViewModel(
        ILogger<PhoneViewModel> logger,
        HomeViewModel homeViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authenticaion)
    {
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
            homeViewModel.ShowSignInError("Please first .");
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            homeViewModel.ShowSignInError("The verification code field cannot be empty.");
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
            homeViewModel.ShowSignInError("The phone number field cannot be empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            homeViewModel.ShowSignInError("Please first fill the reCAPTCHA.");
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
            homeViewModel.ShowSignInError(ex.Message);
        }
    }
}