namespace Firebase.Authentication.Exceptions;

public class CredentialAlreadyExistException : IdentityPlatformException
{
    /// <summary>
    /// Credentials already exist. You first have to sign out.
    /// </summary>
    public CredentialAlreadyExistException() : base("Credentials already exist. You first have to sign out.", "CREDENTIAL_ALREADY_EXIST") { }
}