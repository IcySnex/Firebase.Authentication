namespace Firebase.Authentication.Exceptions;

public class MissingIdTokenException : AuthenticationException
{
    /// <summary>
    /// Request contains an invalid value for parameter: idToken.
    /// </summary>
    public MissingIdTokenException() : base("MISSING_ID_TOKEN", "Request contains an invalid value for parameter: idToken.") { }
}