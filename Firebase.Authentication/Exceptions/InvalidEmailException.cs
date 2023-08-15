namespace Firebase.Authentication.Exceptions;

public class InvalidEmailException : IdentityPlatformException
{
    /// <summary>
    /// The email address is badly formatted.
    /// </summary>
    public InvalidEmailException() : base("INVALID_EMAIL", "The email address is badly formatted.") { }
}