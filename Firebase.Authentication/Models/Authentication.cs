namespace Firebase.Authentication.Models;

/// <summary>
/// Model for an Authentication
/// </summary>
public class Authentication
{
    /// <summary>
    /// Creates a new Authentication
    /// </summary>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the RefreshToken</param>
    public Authentication(
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
    /// The expiration timespan for the RefreshToken
    /// </summary>
    public TimeSpan ExpiresIn { get; }


    /// <summary>
    /// The date and time when this authenticaion was recieved
    /// </summary>
    public DateTime Recieved { get; } = DateTime.Now;

    /// <summary>
    /// A boolean wether the authenticaion is expired
    /// </summary>
    public bool IsExpired =>
        DateTime.Now > Recieved.Add(ExpiresIn);
}