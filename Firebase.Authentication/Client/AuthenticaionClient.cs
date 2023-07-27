using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Exceptions;
using Firebase.Authentication.Models;
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
    }


    /// <summary>
    /// Occurrs when a property value changes
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual bool SetProperty<T>(
        ref T field, T newValue,
        [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;

        T oldValue = field;
        field = newValue;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs<T>(propertyName, oldValue, newValue));
        return true;
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
    /// The user who is currently logged into the client 
    /// </summary>
    public UserInfo? CurrentUser
    {
        get => currentUser;
        private set => SetProperty(ref currentUser, value);
    }

    UserInfo? currentUser;


    /// <summary>
    /// Checks if current credential is null and throws if so
    /// </summary>
    /// <exception cref="MissingCredentialException">Occurrs when the current credential is null</exception>
    void ThrowIfMissingCredential()
    {
        if (CurrentCredential is null)
        {
            logger?.LogError("[AuthenticaionClient-GetFreshCredentialAsync] MISSING_CREDENTIAL: A login is required before calling this function.");
            throw new MissingCredentialException();
        }
    }



    /// <summary>
    /// Checks if the current credential is expired and if so sends a refresh request 
    /// </summary>
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
    /// <exception cref="System.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    public async Task<Credential> GetFreshCredentialAsync(
        CancellationToken cancellationToken = default)
    {
        ThrowIfMissingCredential();

        if (!CurrentCredential!.IsExpired)
        {
            logger?.LogInformation("[AuthenticaionClient-GetFreshCredentialAsync] Current credential not expired: Returned current credential.");
            return CurrentCredential;
        }

        SecureTokenRequest request = new(CurrentCredential.RefreshToken);
        SecureTokenResponse response = await baseClient.SecureTokenAsync(request, cancellationToken);
        logger?.LogInformation("[AuthenticaionClient-GetFreshCredentialAsync] Excahnged refresh token for a new ID token.");

        CurrentCredential = new(response.IdToken, response.RefreshToken, response.ExpiresIn);
        return CurrentCredential;
    }
}