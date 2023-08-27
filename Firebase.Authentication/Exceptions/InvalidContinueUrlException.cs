namespace Firebase.Authentication.Exceptions;

public class InvalidContinueUrlException : IdentityPlatformException
{
    /// <summary>
    /// The given continue URL is not a valid formatted URI
    /// </summary>
    public InvalidContinueUrlException() : base("The given continue URL is not a valid formatted URI", "INVALID_CONTINUE_URI") { }
}