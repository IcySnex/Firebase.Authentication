namespace Firebase.Authentication.Exceptions;

public class InvalidContinueUrlException : AuthenticationException
{
    /// <summary>
    /// The given continue URL is not a valid formatted URI
    /// </summary>
    public InvalidContinueUrlException() : base("INVALID_CONTINUE_URI", "The given continue URL is not a valid formatted URI") { }
}