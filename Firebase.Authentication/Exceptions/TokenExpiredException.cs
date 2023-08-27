namespace Firebase.Authentication.Exceptions;

public class TokenExpiredException : IdentityPlatformException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public TokenExpiredException() : base("The user's credential is no longer valid. The user must sign in again.", "TOKEN_EXPIRED") { }
}