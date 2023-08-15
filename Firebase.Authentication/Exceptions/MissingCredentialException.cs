namespace Firebase.Authentication.Exceptions;

public class MissingCredentialException : IdentityPlatformException
{
    /// <summary>
    /// Credentials are missing. You first have to sign in.
    /// </summary>
    public MissingCredentialException() : base("MISSING_CREDENTIAL", "Credentials are missing. You first have to sign in.") { }
}