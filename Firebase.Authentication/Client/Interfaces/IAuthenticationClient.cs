using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using System.ComponentModel;

namespace Firebase.Authentication.Client.Interfaces;

/// <summary>
/// Client for all high level Firebase Authentication actions
/// </summary>
public interface IAuthenticationClient : INotifyPropertyChanged
{

    /// <summary>
    /// The current users authenitcaion credential
    /// </summary>
    public Credential? CurrentCredential { get; }

    /// <summary>
    /// Checks if the current credential is expired and if so sends a refresh request 
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
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
    public Task<Credential> GetFreshCredentialAsync(
        CancellationToken cancellationToken = default);


    /// <summary>
    /// The user who is currently signed into the client 
    /// </summary>
    public UserInfo? CurrentUser { get; }

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
    public Task<UserInfo> GetFreshUserAsync(
        TimeSpan? validityPeriod = null,
        CancellationToken cancellationToken = default);


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
    public Task SignInAsync(
        SignInRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs out the current user by deleting the current credential and user info
    /// </summary>
    public void SignOut();
}