namespace Firebase.Authentication.Exceptions;

public class InvalidPasswordException : IdentityPlatformException
{
    /// <summary>
    /// The password is invalid or the user does not have a password.
    /// </summary>
    public InvalidPasswordException() : base("The password is invalid or the user does not have a password.", "INVALID_PASSWORD") { }
}