namespace Firebase.Authentication.Exceptions;

public class InvalidIdTokenException : IdentityPlatformException
{
    /// <summary>
    /// The user's credential is no longer valid. The user must sign in again.
    /// </summary>
    public InvalidIdTokenException() : base("The user's credential is no longer valid. The user must sign in again.", "INVALID_ID_TOKEN") { }
}