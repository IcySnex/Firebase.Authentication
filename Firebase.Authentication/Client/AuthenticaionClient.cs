using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Exceptions;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;
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
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
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
        SecureTokenRequest request = new(CurrentCredential.RefreshToken);
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
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    public async Task<UserInfo> GetFreshUserAsync(
        TimeSpan? validityPeriod = null,
        CancellationToken cancellationToken = default)
    {
        // Validation
        ThrowIfMissingCredential();
        ThrowIfCredentialExpired();

        if (CurrentUser is not null && validityPeriod.HasValue && CurrentUser.Recieved.Add(validityPeriod.Value) > DateTime.Now)
        {
            logger?.LogInformation("[AuthenticaionClient-GetFreshUserAsync] Current user info is still valid: Returned current user info.");
            return CurrentUser;
        }

        // Send request
        LookupRequest request = new(CurrentCredential!.IdToken);
        LookupResponse response = await baseClient.LookupAsync(request, cancellationToken);

        if (response.Users.Length == 0)
        {
            logger?.LogError("[AuthenticaionClient-GetFreshUserAsync] USER_NOT_FOUND: The user corresponding to the refresh token/identifier was not found. The user may have been deleted.");
            throw new UserNotFoundException();
        }
        CurrentUser = response.Users[0];

        logger?.LogInformation("[AuthenticaionClient-GetFreshUserAsync] Refreshed the current user info.");
        return CurrentUser;
    }


    /// <summary>
    /// Signs in an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign in request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
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
        }

        // Refresh current user
        await GetFreshUserAsync();
    }

    /// <summary>
    /// Signs out the current user by deleting the current credential and user info
    /// </summary>
    public void SignOut()
    {
        CurrentCredential = null;
        CurrentUser = null;
    }
}