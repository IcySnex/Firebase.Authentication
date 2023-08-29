namespace Firebase.Authentication.Exceptions;

public class InvalidCodeException : IdentityPlatformException
{
    /// <summary>
    /// The passed verification code was invalid.
    /// </summary>
    public InvalidCodeException() : base("INVALID_CODE", "The passed verification code was invalid.") { }
}