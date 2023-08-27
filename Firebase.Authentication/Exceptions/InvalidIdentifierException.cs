namespace Firebase.Authentication.Exceptions;

public class InvalidIdentifierException : IdentityPlatformException
{
    /// <summary>
    /// An invalid identifier was passed.
    /// </summary>
    public InvalidIdentifierException() : base("An invalid identifier was passed.", "INVALID_IDENTIFIER") { }
}