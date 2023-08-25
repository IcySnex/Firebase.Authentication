namespace Firebase.Authentication.Client.Interfaces;

/// <summary>
/// Handles 3rd party OAuth provider authentication
/// </summary>
public interface IProviderFlow
{
    /// <summary>
    /// Signs in the given client with this provider flow
    /// </summary>
    /// <param name="authentication">The authentication client to sign into</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task SignInAsync(
        IAuthenticationClient authentication,
        CancellationToken cancellationToken = default!);

    /// <summary>
    /// Links the current user of the given client with this provider flow
    /// </summary>
    /// <param name="authentication">The authentication client to sign into</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task LinkAsync(
        IAuthenticationClient authentication,
        CancellationToken cancellationToken = default);
}