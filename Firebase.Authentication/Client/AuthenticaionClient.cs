using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Exceptions;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Firebase.Authentication.Client;

/// <summary>
/// Client for all high level Firebase Authentication actions implementing INotifyPropertyChanged
/// </summary>
public class AuthenticaionClient : IAuthenticationClient, INotifyPropertyChanged
{
    readonly IAuthenticationBase baseClient;

    readonly ILogger<IAuthenticationClient>? logger;

    /// <summary>
    /// Creates a new AuthenticaionClient
    /// </summary>
    /// <param name="config">The configuration the AuthenticationClient should be created</param>
    public AuthenticaionClient(
        AuthenticationConfig config)
    {
        baseClient = new AuthenticationBase(config);
    }

    /// <summary>
    /// Creates a new AuthenticaionClient with extendended logging functions
    /// </summary>
    /// <param name="config">The configuration the AuthenticationClient should be created</param>
    /// <param name="logger">The logger which will be used to log</param>
    public AuthenticaionClient(
        AuthenticationConfig config,
        ILogger<IAuthenticationClient>? logger)
    {
        baseClient = new AuthenticationBase(config, logger);

        this.logger = logger;
        logger?.LogInformation($"[AuthenticaionClient-.ctor] AuthenticaionClient has been initialized.");
    }

    /// <summary>
    /// Creates a new AuthenticaionClient
    /// </summary>
    /// <param name="baseClient">Underlaying base client used for all low level identity platform accounts actions</param>
    public AuthenticaionClient(
        IAuthenticationBase baseClient)
    {
        this.baseClient = baseClient;
    }

    /// <summary>
    /// Creates a new AuthenticaionClient with extendended logging functions
    /// </summary>
    /// <param name="baseClient">Underlaying base client used for all low level identity platform accounts actions</param>
    /// <param name="logger">The logger which will be used to log</param>
    public AuthenticaionClient(
        IAuthenticationBase baseClient,
        ILogger<IAuthenticationClient>? logger)
    {
        this.baseClient = baseClient;

        this.logger = logger;
        logger?.LogInformation($"[AuthenticaionClient-.ctor] AuthenticaionClient has been initialized.");
    }



    /// <summary>
    /// Occurrs when a property value changes
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual bool SetProperty<T>(
        ref T field, T newValue,
        [CallerMemberName] string propertyName = "")
    {
        // Check if current value already eqauls new value
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;

        // Update current value
        T oldValue = field;
        field = newValue;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs<T>(propertyName, oldValue, newValue));
        return true;
    }


    /// <summary>
    /// Checks if current credential is null and throws if so
    /// </summary>
    /// <exception cref="MissingCredentialException">Occurrs when the current credential is null</exception>
    void ThrowIfMissingCredential()
    {
        if (CurrentCredential is not null)
            return;

        logger?.LogError("[AuthenticaionClient-ThrowIfMissingCredential] MISSING_CREDENTIAL: You first have to sign in.");
        throw new MissingCredentialException();
    }

    /// <summary>
    /// Checks if current credential is not null and throws if so
    /// </summary>
    /// <exception cref="CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    void ThrowIfCredentialAlreadyExist()
    {
        if (CurrentCredential is null)
            return;

        logger?.LogError("[AuthenticaionClient-ThrowIfCredentialAlreadyExist] CREDENTIAL_ALREADY_EXIST: You first have to sign out.");
        throw new CredentialAlreadyExistException();
    }

    /// <summary>
    /// Checks if current credential is expired and throws if so
    /// </summary>
    /// <exception cref="CredentialTooOldException">Occurrs when the current credential is expired</exception>
    void ThrowIfCredentialExpired()
    {
        if (!CurrentCredential!.IsExpired)
            return;

        logger?.LogError("[AuthenticaionClient-ThrowIfCredentialExpired] CREDENTIAL_TOO_OLD_LOGIN_AGAIN: The user's credential is no longer valid. The user must sign in again.");
        throw new CredentialTooOldException();
    }


    /// <summary>
    /// The current users authenitcaion credential
    /// </summary>
    public Credential? CurrentCredential
    {
        get => currentCredential;
        private set => SetProperty(ref currentCredential, value);
    }

    Credential? currentCredential;

    /// <summary>
    /// Checks if the current credential is expired and if so sends a refresh request 
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always valid authenticaion credential</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task<Credential> GetFreshCredentialAsync(
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfMissingCredential();

        if (!CurrentCredential!.IsExpired)
        {
            logger?.LogInformation("[AuthenticaionClient-GetFreshCredentialAsync] Current credential not expired: Returned current credential.");
            return CurrentCredential;
        }

        // Send request
        SecureTokenRequest request = new(
            refreshToken: CurrentCredential.RefreshToken);
        SecureTokenResponse response = await baseClient.SecureTokenAsync(request, cancellationToken);
        CurrentCredential = new(response.IdToken, response.RefreshToken, response.ExpiresIn);

        logger?.LogInformation("[AuthenticaionClient-GetFreshCredentialAsync] Exchanged refresh token for a new ID token.");
        return CurrentCredential;
    }


    /// <summary>
    /// The user who is currently signed into the client 
    /// </summary>
    public UserInfo? CurrentUser
    {
        get => currentUser;
        private set => SetProperty(ref currentUser, value);
    }

    UserInfo? currentUser;

    /// <summary>
    /// Checks if the current user is valid based on the given period and if not sends a user data request 
    /// </summary>
    /// <param name="validityPeriod">The time span at which the user should be refreshed to maintain up-to-date information. Null if it should always return a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always uo to date user info</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialTooOldException">Occurrs when the current credential is expired</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task<UserInfo> GetFreshUserAsync(
        TimeSpan? validityPeriod = null,
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfMissingCredential();
        ThrowIfCredentialExpired();

        if (CurrentUser is not null && CurrentUser.IsValid)
        {
            logger?.LogInformation("[AuthenticaionClient-GetFreshUserAsync] Current user info is still valid: Returned current user info.");
            return CurrentUser;
        }

        // Send request
        LookupRequest request = new(
            idToken: CurrentCredential!.IdToken);
        LookupResponse response = await baseClient.LookupAsync(request, cancellationToken);

        if (response.Users.Length == 0)
        {
            logger?.LogError("[AuthenticaionClient-GetFreshUserAsync] USER_NOT_FOUND: The user corresponding to the refresh token/identifier was not found. The user may have been deleted.");
            throw new UserNotFoundException();
        }
        CurrentUser = response.Users[0];
        CurrentUser.ValidityPeriod = validityPeriod;

        logger?.LogInformation("[AuthenticaionClient-GetFreshUserAsync] Refreshed the current user info.");
        return CurrentUser;
    }


    /// <summary>
    /// Signs up an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign up request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task SignUpAsync(
        Requests.SignUpRequest request,
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfCredentialAlreadyExist();

        // Send request
        SignUpResponse response = await baseClient.SignUpAsync((Requests.Base.SignUpRequest)request, cancellationToken);
        CurrentCredential = new(response.IdToken, response.RefreshToken, response.ExpiresIn);

        logger?.LogInformation("[AuthenticaionClient-SignUpAsync] Signed up.");

        // Refresh current user
        await GetFreshUserAsync(CurrentCredential.ExpiresIn);
    }

    /// <summary>
    /// Signs in an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign in request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task SignInAsync(
        SignInRequest request,
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfCredentialAlreadyExist();

        switch (request)
        {
            // Send sign in with password request
            case SignInWithPasswordRequest passwordRequest:
                SignInWithPasswordResponse passwordResponse = await baseClient.SignInWithPasswordAsync(passwordRequest, cancellationToken);
                CurrentCredential = new(passwordResponse.IdToken, passwordResponse.RefreshToken, passwordResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticaionClient-SignInAsync] Signed in with password.");
                break;

            // Send sign in with custom token request
            case SignInWithCustomTokenRequest customTokenRequest:
                SignInWithCustomTokenResponse customTokenResponse = await baseClient.SignInWithCustomTokenAsync(customTokenRequest, cancellationToken);
                CurrentCredential = new(customTokenResponse.IdToken, customTokenResponse.RefreshToken, customTokenResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticaionClient-SignInAsync] Signed in with custom token.");
                break;

            // Send sign in with phonenumber request
            case SignInWithPhoneNumberRequest phoneNumberRequest:
                SignInWithPhoneNumberResponse phoneNumberResponse = await baseClient.SignInWithPhoneNumberAsync(phoneNumberRequest, cancellationToken);
                CurrentCredential = new(phoneNumberResponse.IdToken, phoneNumberResponse.RefreshToken, phoneNumberResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticaionClient-SignInAsync] Signed in with phone number.");
                break;

            // Send sign in with phonenumber request
            case SignInWithEmailLinkRequest emailLinkRequest:
                SignInWithEmailLinkResponse emailLinkResponse = await baseClient.SignInWithEmailLinkAsync(emailLinkRequest, cancellationToken);
                CurrentCredential = new(emailLinkResponse.IdToken, emailLinkResponse.RefreshToken, emailLinkResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticaionClient-SignInAsync] Signed in with phone number.");
                break;
        }

        // Refresh current user
        await GetFreshUserAsync(CurrentCredential!.ExpiresIn);
    }

    /// <summary>
    /// Signs out the current user by deleting the current credential and user info
    /// </summary>
    public void SignOut()
    {
        CurrentCredential = null;
        CurrentUser = null;
    }


    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialTooOldException">Occurrs when the current credential is expired</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task DeleteAsync(
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfMissingCredential();
        ThrowIfCredentialExpired();

        // Send request
        DeleteRequest request = new(
            idToken: CurrentCredential!.IdToken);
        await baseClient.DeleteAsync(request, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-DeleteAsync] Deleted the current user.");
        SignOut();
    }

    /// <summary>
    /// Changes the current users password
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialTooOldException">Occurrs when the current credential is expired</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task ChangePasswordAsync(
        string newPassword,
        string oldPassword,
        CancellationToken cancellationToken = default)
    {
        // Get current account
        UserInfo currentUser = await GetFreshUserAsync(TimeSpan.FromHours(1));

        // Send request
        ResetPasswordRequest request = new(
            newPassword: newPassword,
            oldPassword: oldPassword,
            email: currentUser.Email);
        await baseClient.ResetPasswordASync(request, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-ResetPasswordAsync] Changed the current users password.");
    }

    /// <summary>
    /// Sends a new verify email to the current users account
    /// </summary>
    /// <param name="request">The email request</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">May occurs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialTooOldException">May occurs when the current credential is expired</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task SendEmailAsync(
        EmailRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default)
    {
        // Prepare request and validation
        SendOobCodeRequest oobRequest = (SendOobCodeRequest)request;
        switch (oobRequest.RequestType)
        {
            case OobType.VerifyEmail:
            case OobType.VerifyAndChangeEmail:
                ThrowIfMissingCredential();
                ThrowIfCredentialExpired();

                oobRequest.IdToken = CurrentCredential!.IdToken;
                break;
        }

        // Send request
        SendOobCodeResponse response = await baseClient.SendOobCodeAsync(oobRequest, locale, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-SendEmailAsync] Sent a email to the account.");
    }


    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="newPassword">The new password to be set for this account</param>
    /// <param name="code">An out-of-band (OOB) code generated by an prior request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The email associated with the password reset</returns>
    public async Task<string> ResetPasswordAsync(
        string newPassword,
        string code,
        CancellationToken cancellationToken = default)
    {
        // Send request
        ResetPasswordRequest request = new(
            newPassword: newPassword,
            oobCode: code);
        ResetPasswordResponse response = await baseClient.ResetPasswordASync(request, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-ResetPasswordAsync] Reset the users password.");
        return response.Email;
    }

    /// <summary>
    /// Sends a SMS verification code for phone number sign-in.
    /// </summary>
    /// <param name="phoneNumber">The phone number to send the verification code to in E.164 format</param>
    /// <param name="recaptchaToken">Recaptcha token for app verification.<br/> To easily get an official Google reCAPTCHA token on WPF, WinUI, UWP, WinForms or console you can use <see href="https://icysnex.github.io/ReCaptcha.Desktop/"/>.<br/> You can use <see cref="IAuthenticationBase.GetRecaptchaParamsAsync(CancellationToken)"/> to get a reCAPTCHA site key for your current project</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The Encrypted session information which can be used to sign in with the phone number</returns>
    public async Task<string> SendVerificationCodeAsync(
        string phoneNumber,
        string recaptchaToken,
        string? locale = null,
        CancellationToken cancellationToken = default)
    {
        // Send request
        SendVerificationCodeRequest request = new(
            phoneNumber: phoneNumber,
            recaptchaToken: recaptchaToken);
        SendVerificationCodeResponse response = await baseClient.SendVerificationCodeAsync(request, locale, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-SendSmsCodeAsync] Sent verification code to phone number.");
        return response.SessionInfo;
    }

    /// <summary>
    /// Checks and returns if any user account is registered with the email. If there is a registered account, fetches all providers associated with the accounts email
    /// </summary>
    /// <param name="email">The email of the users account to fetch associated providers for</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>A list of sign in methods for the users account. Null if email is not registered</returns>
    public async Task<Provider[]?> GetSignInMethods(
        string email,
        string continueUri = "http://localhost",
        CancellationToken cancellationToken = default)
    {
        // Send request
        CreateAuthUriRequest request = new(
            continueUri: continueUri,
            identifier: email);
        CreateAuthUrlResponse response = await baseClient.CreateAuthUriAsync(request, cancellationToken);

        logger?.LogInformation("[AuthenticaionClient-SendSmsCodeAsync] Sent verification code to phone number.");
        return response.SigninMethods;
    }
}