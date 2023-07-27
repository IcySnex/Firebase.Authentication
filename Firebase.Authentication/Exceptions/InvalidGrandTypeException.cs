namespace Firebase.Authentication.Exceptions;

public class InvalidGrandTypeException : AuthenticationException
{
    /// <summary>
    /// the grant type specified is invalid.
    /// </summary>
    public InvalidGrandTypeException() : base("INVALID_GRANT_TYPE", "the grant type specified is invalid.") { }
}