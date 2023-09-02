using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WPF.Helpers;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.WPF.Client.Interfaces;

namespace Firebase.Authentication.Sample.WPF.ViewModels;

public partial class LinkPhoneViewModel : ObservableObject
{
    readonly ILogger<LinkPhoneViewModel> logger;
    readonly LinkViewModel linkViewModel;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authenticaion;

    public LinkPhoneViewModel(
        ILogger<LinkPhoneViewModel> logger,
        LinkViewModel linkViewModel,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authenticaion)
    {
        this.logger = logger;
        this.linkViewModel = linkViewModel;
        this.reCaptcha = reCaptcha;
        this.authenticaion = authenticaion;

        logger.LogInformation("[LinkPhoneViewModel-.ctor] LinkPhoneViewModel has been initialized.");
    }


    [RelayCommand]
    void NavigateBack() =>
        linkViewModel.Navigate<LinkProviderViewModel>();


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
    async Task LinkAsync()
    {
        if (sessionInfo is null)
        {
            logger.LogErrorAndShow("Please first send a verification code.", "Linking failed", "LinkPhoneViewModel-LinkAsync");
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            logger.LogErrorAndShow("The verification code field cannot be empty.", "Link failed", "LinkPhoneViewModel-LinkAsync");
            return;
        }

        if (await linkViewModel.LinkAsync(LinkRequest.ToPhoneNumber(sessionInfo, Code)))
            linkViewModel.Navigate<LinkProviderViewModel>();
    }


    [RelayCommand]
    async Task SendCodeAsync()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            logger.LogErrorAndShow("The phone number field cannot be empty.", "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync");
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            logger.LogErrorAndShow("Please first fill the reCAPTCHA.", "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync");
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
            logger.LogErrorAndShow(ex, "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync");
        }
    }
}