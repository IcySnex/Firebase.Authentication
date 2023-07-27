namespace Firebase.Authentication.Exceptions;

public class CredentialMismatchException : AuthenticationException
{
    /// <summary>
    /// The custom token corresponds to a different Firebase project.
    /// </summary>
    public CredentialMismatchException() : base("CREDENTIAL_MISMATCH", "The custom token corresponds to a different Firebase project.") { }
}