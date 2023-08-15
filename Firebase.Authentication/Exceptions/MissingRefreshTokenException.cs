namespace Firebase.Authentication.Exceptions;

public class MissingRefreshTokenException : IdentityPlatformException
{
    /// <summary>
    /// no refresh token provided.
    /// </summary>
    public MissingRefreshTokenException() : base("MISSING_REFRESH_TOKEN", "no refresh token provided.") { }
}