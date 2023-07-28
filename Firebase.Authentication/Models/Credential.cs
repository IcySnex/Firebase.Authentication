namespace Firebase.Authentication.Models;

/// <summary>
/// Contains information about the current users authentication tokens
/// </summary>
public class Credential
{
    /// <summary>
    /// Creates a new Credential
    /// </summary>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    public Credential(
        string idToken,
        string refreshToken,
        TimeSpan expiresIn)
    {
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    public string IdToken { get; }

    /// <summary>
    /// An Identity Platform refresh token for the authenticated user
    /// </summary>
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration timespan for the ID token
    /// </summary>
    public TimeSpan ExpiresIn { get; }


    /// <summary>
    /// The date and time when this credential was recieved
    /// </summary>
    public DateTime Recieved { get; } = DateTime.Now;

    /// <summary>
    /// A boolean wether the credential is expired
    /// </summary>
    public bool IsExpired =>
        DateTime.Now > Recieved.Add(ExpiresIn);
}