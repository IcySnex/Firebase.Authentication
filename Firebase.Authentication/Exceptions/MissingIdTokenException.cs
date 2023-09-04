namespace Firebase.Authentication.Exceptions;

public class MissingIdTokenException : IdentityPlatformException
{
    /// <summary>
    /// No id token provided.
    /// </summary>
    public MissingIdTokenException() : base("No id token provided.", "MISSING_ID_TOKEN") { }
}