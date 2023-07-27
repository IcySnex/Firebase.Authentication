namespace Firebase.Authentication.Exceptions;

public class EmailNotFoundException : AuthenticationException
{
    /// <summary>
    /// There is no user record corresponding to this identifier. The user may have been deleted.
    /// </summary>
    public EmailNotFoundException() : base("EMAIL_NOT_FOUND", "There is no user record corresponding to this identifier. The user may have been deleted.") { }
}