namespace Firebase.Authentication.Exceptions;

public class MissingCredentialException : IdentityPlatformException
{
    /// <summary>
    /// Credentials are missing. First sign in or validate provider flow.
    /// </summary>
    public MissingCredentialException() : base("Credentials are missing. First sign in or validate provider flow.", "MISSING_CREDENTIAL") { }
}