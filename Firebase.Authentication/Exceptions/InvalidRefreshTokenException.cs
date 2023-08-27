namespace Firebase.Authentication.Exceptions;

public class InvalidRefreshTokenException : IdentityPlatformException
{
    /// <summary>
    /// An invalid refresh token is provided.
    /// </summary>
    public InvalidRefreshTokenException() : base("An invalid refresh token is provided.", "INVALID_REFRESH_TOKEN") { }
}