namespace Firebase.Authentication.Exceptions;

public class MissingRefreshTokenException : IdentityPlatformException
{
    /// <summary>
    /// no refresh token provided.
    /// </summary>
    public MissingRefreshTokenException() : base("No refresh token provided.", "MISSING_REFRESH_TOKEN") { }
}