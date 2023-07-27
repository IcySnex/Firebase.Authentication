namespace Firebase.Authentication.Exceptions;

public class InvalidIdentifierException : AuthenticationException
{
    /// <summary>
    /// An invalid identifier was passed.
    /// </summary>
    public InvalidIdentifierException() : base("INVALID_IDENTIFIER", "An invalid identifier was passed.") { }
}