namespace Firebase.Authentication.Exceptions;

public class MissingNewEmailException : IdentityPlatformException
{
    /// <summary>
    /// New email is missing on request. Please specify an email address to change to.
    /// </summary>
    public MissingNewEmailException() : base("New email is missing on request. Please specify an email address to change to.", "MISSING_NEW_EMAIL") { }
}