namespace Firebase.Authentication.Exceptions;

public class MissingEmailException : IdentityPlatformException
{
    /// <summary>
    /// No email provided.
    /// </summary>
    public MissingEmailException() : base("MISSING_EMAIL", "No email provided.") { }
}