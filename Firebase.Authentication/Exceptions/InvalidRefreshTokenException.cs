namespace Firebase.Authentication.Exceptions;

public class InvalidRefreshTokenException : AuthenticationException
{
    /// <summary>
    /// An invalid refresh token is provided.
    /// </summary>
    public InvalidRefreshTokenException() : base("INVALID_REFRESH_TOKEN", "An invalid refresh token is provided.") { }
}