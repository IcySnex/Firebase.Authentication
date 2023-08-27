namespace Firebase.Authentication.Exceptions;

public class MissingEmailException : IdentityPlatformException
{
    /// <summary>
    /// No email provided.
    /// </summary>
    public MissingEmailException() : base("No email provided.", "MISSING_EMAIL") { }
}