namespace Firebase.Authentication.Exceptions;

public class SessionExpiredException : AuthenticationException
{
    /// <summary>
    /// The session has expired. Please re-send the verification code to try again.
    /// </summary>
    public SessionExpiredException() : base("SESSION_EXPIRED", "The session has expired. Please re-send the verification code to try again.") { }
}