namespace Firebase.Authentication.Exceptions;

public class CredentialTooOldException : IdentityPlatformException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public CredentialTooOldException() : base("The user's credential is no longer valid. The user must sign in again.", "CREDENTIAL_TOO_OLD_LOGIN_AGAIN") { }
}