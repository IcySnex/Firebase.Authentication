namespace Firebase.Authentication.Exceptions;

public class MissingCredentialException : AuthenticationException
{
    /// <summary>
    /// Credentials are missing. You first have to sign in.
    /// </summary>
    public MissingCredentialException() : base("MISSING_CREDENTIAL", "Credentials are missing. You first have to sign in.") { }
}