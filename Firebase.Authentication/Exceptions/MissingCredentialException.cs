namespace Firebase.Authentication.Exceptions;

public class MissingCredentialException : AuthenticationException
{
    /// <summary>
    /// Credentials are missing. A login is required before calling this function.
    /// </summary>
    public MissingCredentialException() : base("MISSING_CREDENTIAL", "Credentials are missing. A login is required before calling this function.") { }
}