namespace Firebase.Authentication.Exceptions;

public class MissingRefreshTokenException : IdentityPlatformException
{
    /// <summary>
    /// no refresh token provided.
    /// </summary>
    public MissingRefreshTokenException() : base("no refresh token provided.", "MISSING_REFRESH_TOKEN") { }
}