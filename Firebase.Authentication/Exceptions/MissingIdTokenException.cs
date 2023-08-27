namespace Firebase.Authentication.Exceptions;

public class MissingIdTokenException : IdentityPlatformException
{
    /// <summary>
    /// Request contains an invalid value for parameter: idToken.
    /// </summary>
    public MissingIdTokenException() : base("Request contains an invalid value for parameter: idToken.", "MISSING_ID_TOKEN") { }
}