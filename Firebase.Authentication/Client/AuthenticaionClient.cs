using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Exceptions;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace Firebase.Authentication.Client;

/// <summary>
/// Client for all high level Firebase Authentication actions implementing INotifyPropertyChanged
/// </summary>
public class AuthenticationClient : IAuthenticationClient, INotifyPropertyChanged
{
    readonly IIdentityPlatformClient identityPlatform;

    readonly ILogger<IAuthenticationClient>? logger;

    /// <summary>
    /// Creates a new AuthenticationClient
    /// </summary>
    /// <param name="config">The configuration the Identity Platform client should be created with</param>
    public AuthenticationClient(
        AuthenticationConfig config)
    {
        identityPlatform = new IdentityPlatformClient(config);
    }

    /// <summary>
    /// Creates a new AuthenticationClient with extendended logging functions
    /// </summary>
    /// <param name="config">The configuration the Identity Platform client should be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    public AuthenticationClient(
        AuthenticationConfig config,
        ILogger<IAuthenticationClient> logger)
    {
        identityPlatform = new IdentityPlatformClient(config, logger);

        this.logger = logger;
        logger.LogInformation($"[AuthenticationClient-.ctor] AuthenticationClient has been initialized.");
    }

    /// <summary>
    /// Creates a new AuthenticationClient
    /// </summary>
    /// <param name="identityPlatform">Underlaying Identity Platform client used for all low level identity platform accounts actions</param>
    public AuthenticationClient(
        IIdentityPlatformClient identityPlatform)
    {
        this.identityPlatform = identityPlatform;
    }

    /// <summary>
    /// Creates a new AuthenticationClient with extendended logging functions
    /// </summary>
    /// <param name="identityPlatform">Underlaying Identity Platform client used for all low level identity platform accounts actions</param>
    /// <param name="logger">The logger which will be used to log</param>
    public AuthenticationClient(
        IIdentityPlatformClient identityPlatform,
        ILogger<IAuthenticationClient> logger)
    {
        this.identityPlatform = identityPlatform;

        this.logger = logger;
        logger.LogInformation($"[AuthenticationClient-.ctor] AuthenticationClient has been initialized.");
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

        logger?.LogError("[AuthenticationClient-ThrowIfMissingCredential] MISSING_CREDENTIAL: You first have to sign in.");
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

        logger?.LogError("[AuthenticationClient-ThrowIfCredentialAlreadyExist] CREDENTIAL_ALREADY_EXIST: You first have to sign out.");
        throw new CredentialAlreadyExistException();
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
    /// <param name="forceRefresh">When true the expiration period of the current credential is ignored it always returns a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always valid Authentication credential</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task<Credential> GetFreshCredentialAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfMissingCredential();

        if (!forceRefresh && !CurrentCredential!.IsExpired)
        {
            logger?.LogInformation("[AuthenticationClient-GetFreshCredentialAsync] Current credential not expired: Returned current credential.");
            return CurrentCredential;
        }

        // Send request
        SecureTokenRequest request = new(
            refreshToken: CurrentCredential!.RefreshToken);
        SecureTokenResponse response = await identityPlatform.SecureTokenAsync(request, cancellationToken);
        CurrentCredential = new(response.IdToken, response.RefreshToken, response.ExpiresIn);

        logger?.LogInformation("[AuthenticationClient-GetFreshCredentialAsync] Exchanged refresh token for a new ID token.");
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
    /// <param name="validityPeriod">The time span at which the user should be refreshed to maintain up-to-date information. Null if a single time user info is wanted</param>
    /// <param name="forceRefresh">When true the validity period of the current user info is ignored it always returns a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always uo to date user info</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task<UserInfo> GetFreshUserAsync(
        TimeSpan? validityPeriod = null,
        bool forceRefresh = false,
        CancellationToken cancellationToken = default)
    {
        // Validation
        if (!forceRefresh && CurrentUser is not null && CurrentUser.IsValid)
        {
            logger?.LogInformation("[AuthenticationClient-GetFreshUserAsync] Current user info is still valid: Returned current user info.");
            return CurrentUser;
        }

        Credential credential = await GetFreshCredentialAsync();

        // Send request
        LookupRequest request = new(
            idToken: credential.IdToken);
        LookupResponse response = await identityPlatform.LookupAsync(request, cancellationToken);

        if (response.Users.Length == 0)
        {
            logger?.LogError("[AuthenticationClient-GetFreshUserAsync] USER_NOT_FOUND: The user corresponding to the refresh token/identifier was not found. The user may have been deleted.");
            throw new UserNotFoundException();
        }
        CurrentUser = response.Users[0];
        CurrentUser.ValidityPeriod = validityPeriod;

        logger?.LogInformation("[AuthenticationClient-GetFreshUserAsync] Refreshed the current user info.");
        return CurrentUser;
    }


    /// <summary>
    /// Signs up an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign up request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
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
        SignUpResponse response = await identityPlatform.SignUpAsync((Requests.IdentityPlatform.SignUpRequest)request, cancellationToken);
        CurrentCredential = new(response.IdToken, response.RefreshToken, response.ExpiresIn);

        logger?.LogInformation("[AuthenticationClient-SignUpAsync] Signed up.");

        // Refresh current user
        await GetFreshUserAsync(CurrentCredential.ExpiresIn);
    }

    /// <summary>
    /// Signs in an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign in request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
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
            default: // This should never occur
                throw new InvalidRequestTypeException();

            case SignInWithPasswordRequest passwordRequest: // Send sign in with password request
                SignInWithPasswordResponse passwordResponse = await identityPlatform.SignInWithPasswordAsync(passwordRequest, cancellationToken);
                CurrentCredential = new(passwordResponse.IdToken, passwordResponse.RefreshToken, passwordResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with password.");
                break;

            case SignInWithCustomTokenRequest customTokenRequest: // Send sign in with custom token request
                SignInWithCustomTokenResponse customTokenResponse = await identityPlatform.SignInWithCustomTokenAsync(customTokenRequest, cancellationToken);
                CurrentCredential = new(customTokenResponse.IdToken, customTokenResponse.RefreshToken, customTokenResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with custom token.");
                break;

            case SignInWithPhoneNumberRequest phoneNumberRequest: // Send sign in with phonenumber request
                SignInWithPhoneNumberResponse phoneNumberResponse = await identityPlatform.SignInWithPhoneNumberAsync(phoneNumberRequest, cancellationToken);
                CurrentCredential = new(phoneNumberResponse.IdToken, phoneNumberResponse.RefreshToken, phoneNumberResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with phone number.");
                break;

            case SignInWithEmailLinkRequest emailLinkRequest: // Send sign in with phonenumber request
                SignInWithEmailLinkResponse emailLinkResponse = await identityPlatform.SignInWithEmailLinkAsync(emailLinkRequest, cancellationToken);
                CurrentCredential = new(emailLinkResponse.IdToken, emailLinkResponse.RefreshToken, emailLinkResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with email link.");
                break;

            case SignInWithIdpRequest idpRequest: // Send sign in with phonenumber request
                SignInWithIdpResponse idpResponse = await identityPlatform.SignInWithIdpAsync(idpRequest, cancellationToken);
                CurrentCredential = new(idpResponse.IdToken, idpResponse.RefreshToken, idpResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with idp.");
                break;

            case SignInWithProviderFlowRequest providerFlowRequest:
                await providerFlowRequest.Flow.SignInAsync(this, cancellationToken);
                if (CurrentCredential is null)
                    throw new MissingCredentialException();

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with provider flow.");
                return;
        }

        // Refresh current user
        await GetFreshUserAsync(CurrentCredential.ExpiresIn, true);
    }

    /// <summary>
    /// Signs out the current user by deleting the current credential and user info
    /// </summary>
    public void SignOut()
    {
        CurrentCredential = null;
        CurrentUser = null;

        logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed out.");
    }


    /// <summary>
    /// Links the current user to the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The link user request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task LinkAsync(
        LinkRequest request,
        CancellationToken cancellationToken = default)
    {
        Credential credential = await GetFreshCredentialAsync();

        switch (request)
        {
            case LinkToPasswordRequest passwordRequest: // Send sign in with password request
                passwordRequest.IdToken = credential.IdToken;
                UpdateResponse passwordResponse = await identityPlatform.UpdateAsync(passwordRequest, null, cancellationToken);
                CurrentCredential = new(passwordResponse.IdToken, credential.RefreshToken, TimeSpan.FromHours(1));

                logger?.LogInformation("[AuthenticationClient-LinkAsync] Linked current user to password.");
                break;

            case LinkToPhoneNumberRequest phoneNumberRequest: // Send sign in with phonenumber request
                phoneNumberRequest.IdToken = credential.IdToken;
                SignInWithPhoneNumberResponse phoneNumberResponse = await identityPlatform.SignInWithPhoneNumberAsync(phoneNumberRequest, cancellationToken);
                CurrentCredential = new(phoneNumberResponse.IdToken, phoneNumberResponse.RefreshToken, phoneNumberResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-LinkAsync] Linked current user to phone number.");
                break;

            case LinkToEmailLinkRequest emailLinkRequest: // Send sign in with phonenumber request
                emailLinkRequest.IdToken = credential.IdToken;
                SignInWithEmailLinkResponse emailLinkResponse = await identityPlatform.SignInWithEmailLinkAsync(emailLinkRequest, cancellationToken);
                CurrentCredential = new(emailLinkResponse.IdToken, emailLinkResponse.RefreshToken, emailLinkResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-LinkAsync] Linked current user to email link.");
                break;

            case LinkToIdpRequest idpRequest: // Send sign in with phonenumber request
                idpRequest.IdToken = credential.IdToken;
                SignInWithIdpResponse idpResponse = await identityPlatform.SignInWithIdpAsync(idpRequest, cancellationToken);
                CurrentCredential = new(idpResponse.IdToken, idpResponse.RefreshToken, idpResponse.ExpiresIn);

                logger?.LogInformation("[AuthenticationClient-LinkAsync] Linked current user to idp.");
                break;

            case LinkToProviderFlowRequest providerFlowRequest:
                await providerFlowRequest.Flow.LinkAsync(this, cancellationToken);
                if (CurrentCredential is null)
                    throw new MissingCredentialException();

                logger?.LogInformation("[AuthenticationClient-SignInAsync] Signed in with provider flow.");
                break;

            default: // This should never occur
                throw new InvalidRequestTypeException();
        }

        // Refresh current user
        await GetFreshUserAsync(CurrentCredential.ExpiresIn, true);
    }

    /// <summary>
    /// Uninks the current user from the given method and refreshes the current user
    /// </summary>
    /// <param name="provider">The provider from which the user is unlinking</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task UnlinkAsync(
        Provider provider,
        CancellationToken cancellationToken = default) =>
        UnlinkAsync(new[] { provider }, cancellationToken);
    /// <summary>
    /// Uninks the current user from the given method and refreshes the current user
    /// </summary>
    /// <param name="providers">The providers from which the user is unlinking</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task UnlinkAsync(
        Provider[] providers,
        CancellationToken cancellationToken = default)
    {
        Credential credential = await GetFreshCredentialAsync();

        // Send request
        Requests.IdentityPlatform.UpdateRequest request = new(
            idToken: credential.IdToken,
            deleteProviders: providers);
        await identityPlatform.UpdateAsync(request, null, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-UnlinkAsync] Unlinked current user from given providers.");

        // Refresh current user
        await GetFreshUserAsync(credential.ExpiresIn, true);
    }

    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task DeleteAsync(
        CancellationToken cancellationToken = default)
    {
        Credential credential = await GetFreshCredentialAsync();

        // Send request
        DeleteRequest request = new(
            idToken: credential.IdToken);
        await identityPlatform.DeleteAsync(request, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-DeleteAsync] Deleted the current user.");
        SignOut();
    }

    /// <summary>
    /// Updates the current users account
    /// </summary>
    /// <param name="displayName">The new display name</param>
    /// <param name="photoUrl">The new photo url</param>
    /// <param name="deleteDisplayName">Wether the display name of the user should be deleted</param>
    /// <param name="deletePhotoUrl">Wether the display name of the user should be deleted</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task UpdateAsync(
        string? displayName,
        string? photoUrl,
        bool deleteDisplayName = false,
        bool deletePhotoUrl = false,
        CancellationToken cancellationToken = default)
    {
        Credential credential = await GetFreshCredentialAsync();

        // Send request
        UpdateRequest request = new(
            idToken: credential.IdToken,
            displayName: displayName,
            photoUrl: photoUrl,
            deleteAttributes: deleteDisplayName ? deletePhotoUrl ? new[] { UserAttributeName.DisplayName, UserAttributeName.PhotoUrl } : new[] { UserAttributeName.DisplayName } : photoUrl is null ? new[] { UserAttributeName.PhotoUrl } : null);
        UpdateResponse response = await identityPlatform.UpdateAsync(request, null, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-UpdateAsync] Updated the current user.");

        // Refresh current user
        if (CurrentUser is null)
        {
            await GetFreshUserAsync(credential.ExpiresIn, true);
            return;
        }
        // Update current users display name and photo url

        CurrentUser = CurrentUser.Copy(response.DisplayName, response.PhotoUrl);
    }

    /// <summary>
    /// Changes the current users password
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task ChangePasswordAsync(
        string newPassword,
        string oldPassword,
        CancellationToken cancellationToken = default)
    {
        UserInfo currentUser = await GetFreshUserAsync(TimeSpan.FromHours(1));

        // Send request
        ResetPasswordRequest request = new(
            newPassword: newPassword,
            oldPassword: oldPassword,
            email: currentUser.Email);
        await identityPlatform.ResetPasswordASync(request, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-ResetPasswordAsync] Changed the current users password.");
    }

    /// <summary>
    /// Sends a new verify email to the current users account
    /// </summary>
    /// <param name="request">The email request</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">May occurs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The email address the email got sent to</returns>
    public async Task<string> SendEmailAsync(
        EmailRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default)
    {
        // Prepare request
        SendOobCodeRequest oobRequest = (SendOobCodeRequest)request;
        switch (oobRequest.RequestType)
        {
            case OobType.VerifyEmail:
            case OobType.VerifyAndChangeEmail:
                Credential credential = await GetFreshCredentialAsync();
                oobRequest.IdToken = credential.IdToken;
                break;
        }

        // Send request
        SendOobCodeResponse response = await identityPlatform.SendOobCodeAsync(oobRequest, locale, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-SendEmailAsync] Sent a email to the account.");
        return response.Email!;
    }


    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="newPassword">The new password to be set for this account</param>
    /// <param name="code">An out-of-band (OOB) code generated by an prior request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
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
        ResetPasswordResponse response = await identityPlatform.ResetPasswordASync(request, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-ResetPasswordAsync] Reset the users password.");
        return response.Email;
    }

    /// <summary>
    /// Checks and returns if any user account is registered with the email. If there is a registered account, fetches all providers associated with the accounts email
    /// </summary>
    /// <param name="email">The email of the users account to fetch associated providers for</param>
    /// <param name="continueUri">Required for Firebase, idk why lol</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>A list of sign in methods for the users account. Null if email is not registered</returns>
    public async Task<Provider[]?> GetSignInProvidersAsync(
        string email,
        string continueUri = "http://localhost",
        CancellationToken cancellationToken = default)
    {
        // Send request
        CreateAuthUriRequest request = new(
            continueUri: continueUri,
            identifier: email);
        CreateAuthUrlResponse response = await identityPlatform.CreateAuthUriAsync(request, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-GetSignInMethodsAsync] Got sign in methods for email.");
        return response.SigninMethods;
    }

    /// <summary>
    /// Sends a SMS verification code for phone number sign-in.
    /// </summary>
    /// <param name="phoneNumber">The phone number to send the verification code to in E.164 format</param>
    /// <param name="recaptchaToken">Recaptcha token for app verification.<br/> To easily get an official Google reCAPTCHA token on WPF, WinUI, UWP, WinForms or console you can use <see href="https://icysnex.github.io/ReCaptcha.Desktop/"/>.<br/> You can use <see cref="IAuthenticationBase.GetRecaptchaParamsAsync(CancellationToken)"/> to get a reCAPTCHA site key for your current project</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
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
        SendVerificationCodeResponse response = await identityPlatform.SendVerificationCodeAsync(request, locale, cancellationToken);

        logger?.LogInformation("[AuthenticationClient-SendVerificationCodeAsync] Sent verification code to phone number.");
        return response.SessionInfo;
    }

    /// <summary>
    /// Creates an authorization URI for the given provider, to which the user can be redirected to for signing in
    /// </summary>
    /// <param name="provider">The email of the users account to fetch associated providers for</param>
    /// <param name="continueUri">The url the user will be redirected back</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>An authorization URI for the requested provider with the respective session id</returns>
    public async Task<ProviderRedirect> CreateProviderRedirectAsync(
        Provider provider,
        string continueUri = "http://localhost",
        CancellationToken cancellationToken = default)
    {
        // Send request
        CreateAuthUriRequest request = new(
            continueUri: continueUri,
            provider: provider);
        CreateAuthUrlResponse response = await identityPlatform.CreateAuthUriAsync(request, cancellationToken);

        if (!response.Provider.HasValue || response.AuthUri is null)
            throw new InvalidProviderIdException();

        ProviderRedirect redirect = new(response.Provider.Value, response.AuthUri, response.SessionId);

        logger?.LogInformation("[AuthenticationClient-GetProviderAuthAsync] Created provider Authentication.");
        return redirect;
    }


    /// <summary>
    /// Gets the reCAPTCHA v2 site key for the current project
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>A reCAPTCHA v2 site key</returns>
    public async Task<string> GetRecaptchaSiteKeyAsync(
        CancellationToken cancellationToken = default)
    {
        // Send request
        RecaptchaParamsResponse response = await identityPlatform.GetRecaptchaParamsAsync(cancellationToken);

        logger?.LogInformation("[AuthenticationClient-GetRecaptchaSiteKeyAsync] Got reCAPTCHA site key.");
        return response.RecaptchaSiteKey;
    }
}