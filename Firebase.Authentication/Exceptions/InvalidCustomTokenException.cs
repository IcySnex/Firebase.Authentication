namespace Firebase.Authentication.Exceptions;

public class InvalidCustomTokenException : IdentityPlatformException
{
    /// <summary>
    /// The custom token format is incorrect or the token is invalid for some reason (e.g. expired, invalid signature etc.)
    /// </summary>
    public InvalidCustomTokenException() : base("The custom token format is incorrect or the token is invalid for some reason (e.g. expired, invalid signature etc.)", "INVALID_CUSTOM_TOKEN") { }
}