namespace Firebase.Authentication.Exceptions;

public class TokenExpiredException : IdentityPlatformException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public TokenExpiredException() : base("TOKEN_EXPIRED", "The user's credential is no longer valid. The user must sign in again.") { }
}