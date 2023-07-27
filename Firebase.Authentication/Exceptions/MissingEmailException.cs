namespace Firebase.Authentication.Exceptions;

public class MissingEmailException : AuthenticationException
{
    /// <summary>
    /// No email provided.
    /// </summary>
    public MissingEmailException() : base("MISSING_EMAIL", "No email provided.") { }
}