namespace Firebase.Authentication.Exceptions;

public class EmailExistsException : AuthenticationException
{
    /// <summary>
    /// The email address is already in use by another account.
    /// </summary>
    public EmailExistsException() : base("EMAIL_EXISTS", "The email address is already in use by another account.") { }
}