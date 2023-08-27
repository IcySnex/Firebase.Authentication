namespace Firebase.Authentication.Exceptions;

public class InvalidEmailException : IdentityPlatformException
{
    /// <summary>
    /// The email address is badly formatted.
    /// </summary>
    public InvalidEmailException() : base("The email address is badly formatted.", "INVALID_EMAIL") { }
}