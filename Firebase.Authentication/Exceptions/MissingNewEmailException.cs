namespace Firebase.Authentication.Exceptions;

public class MissingNewEmailException : AuthenticationException
{
    /// <summary>
    /// New email is missing on request. Please specify an email address to change to.
    /// </summary>
    public MissingNewEmailException() : base("MISSING_NEW_EMAIL", "New email is missing on request. Please specify an email address to change to.") { }
}