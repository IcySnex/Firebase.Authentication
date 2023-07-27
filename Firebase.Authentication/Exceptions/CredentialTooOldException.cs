namespace Firebase.Authentication.Exceptions;

public class CredentialTooOldException : AuthenticationException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public CredentialTooOldException() : base("CREDENTIAL_TOO_OLD_LOGIN_AGAIN", "The user's credential is no longer valid. The user must sign in again.") { }
}