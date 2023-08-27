namespace Firebase.Authentication.Exceptions;

public class SessionExpiredException : IdentityPlatformException
{
    /// <summary>
    /// The session has expired. Please re-send the verification code to try again.
    /// </summary>
    public SessionExpiredException() : base("The session has expired. Please re-send the verification code to try again.", "SESSION_EXPIRED") { }
}