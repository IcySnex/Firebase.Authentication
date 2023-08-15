namespace Firebase.Authentication.Exceptions;

public class CredentialAlreadyExistException : IdentityPlatformException
{
    /// <summary>
    /// Credentials already exist. You first have to sign out.
    /// </summary>
    public CredentialAlreadyExistException() : base("CREDENTIAL_ALREADY_EXIST", "Credentials already exist. You first have to sign out.") { }
}