namespace Firebase.Authentication.Exceptions;

public class MissingSessionIdException : IdentityPlatformException
{
    /// <summary>
    /// Request contains an invalid value for parameter: session_id.
    /// </summary>
    public MissingSessionIdException() : base("MISSING_SESSION_ID", "Request contains an invalid value for parameter: session_id.") { }
}