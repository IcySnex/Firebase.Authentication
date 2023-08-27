namespace Firebase.Authentication.Exceptions;

public class CredentialMismatchException : IdentityPlatformException
{
    /// <summary>
    /// The custom token corresponds to a different Firebase project.
    /// </summary>
    public CredentialMismatchException() : base("The custom token corresponds to a different Firebase project.", "CREDENTIAL_MISMATCH") { }
}