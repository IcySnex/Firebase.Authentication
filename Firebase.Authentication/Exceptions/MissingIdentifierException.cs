namespace Firebase.Authentication.Exceptions;

public class MissingIdentifierException : IdentityPlatformException
{
    /// <summary>
    /// Request contains an invalid value for parameter: identifier.
    /// </summary>
    public MissingIdentifierException() : base("Request contains an invalid value for parameter: identifier.", "MISSING_IDENTIFIER") { }
}