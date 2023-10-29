#nullable enable

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.UWP.Helpers;
using Microsoft.Extensions.Logging;
using ReCaptcha.Desktop.UWP.Client.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Firebase.Authentication.Sample.UWP.ViewModels;

public partial class LinkPhoneViewModel : ObservableObject
{
    readonly ILogger<LinkPhoneViewModel> logger;
    readonly IReCaptchaClient reCaptcha;
    readonly IAuthenticationClient authentication;

    public LinkViewModel LinkViewModel = default!;

    public LinkPhoneViewModel(
        ILogger<LinkPhoneViewModel> logger,
        IReCaptchaClient reCaptcha,
        IAuthenticationClient authentication)
    {
        this.logger = logger;
        this.reCaptcha = reCaptcha;
        this.authentication = authentication;

        logger.LogInformation("[LinkPhoneViewModel-.ctor] LinkPhoneViewModel has been initialized.");
    }


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
    public async Task LinkAsync()
    {
        if (sessionInfo is null)
        {
            await Extensions.AlertErrorAsync("Please first send a verification code.", "Linking failed", "LinkPhoneViewModel-LinkAsync", logger);
            return;
        }
        if (string.IsNullOrWhiteSpace(Code))
        {
            await Extensions.AlertErrorAsync("The verification code field cannot be empty.", "Link failed", "LinkPhoneViewModel-LinkAsync", logger);
            return;
        }

        await LinkViewModel.LinkAsync(LinkRequest.ToPhoneNumber(sessionInfo, Code));
    }


    [RelayCommand]
    async Task SendCodeAsync()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            await Extensions.AlertErrorAsync("The phone number field cannot be empty.", "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync", logger);
            return;
        }

        if (string.IsNullOrWhiteSpace(ReCaptchaToken))
        {
            await Extensions.AlertErrorAsync("Please first fill the reCAPTCHA.", "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync", logger);
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
            await Extensions.AlertErrorAsync(ex, "Sending verification code failed", "LinkPhoneViewModel-SendCodeAsync", logger);
        }
    }
}