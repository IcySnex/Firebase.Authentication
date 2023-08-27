namespace Firebase.Authentication.Exceptions;

public class EmailNotFoundException : IdentityPlatformException
{
    /// <summary>
    /// There is no user record corresponding to this identifier. The user may have been deleted.
    /// </summary>
    public EmailNotFoundException() : base("There is no user record corresponding to this identifier. The user may have been deleted.", "EMAIL_NOT_FOUND") { }
}