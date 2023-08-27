namespace Firebase.Authentication.Exceptions;

public class MissingSessionIdException : IdentityPlatformException
{
    /// <summary>
    /// Request contains an invalid value for parameter: session_id.
    /// </summary>
    public MissingSessionIdException() : base("Request contains an invalid value for parameter: session_id.", "MISSING_SESSION_ID") { }
}