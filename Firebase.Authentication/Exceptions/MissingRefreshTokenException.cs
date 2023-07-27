namespace Firebase.Authentication.Exceptions;

public class MissingRefreshTokenException : AuthenticationException
{
    /// <summary>
    /// no refresh token provided.
    /// </summary>
    public MissingRefreshTokenException() : base("MISSING_REFRESH_TOKEN", "no refresh token provided.") { }
}