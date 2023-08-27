namespace Firebase.Authentication.Exceptions;

public class EmailExistsException : IdentityPlatformException
{
    /// <summary>
    /// The email address is already in use by another account.
    /// </summary>
    public EmailExistsException() : base("The email address is already in use by another account.", "EMAIL_EXISTS") { }
}