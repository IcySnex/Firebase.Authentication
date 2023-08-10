namespace Firebase.Authentication.Exceptions;

public class MissingContinueUriException : AuthenticationException
{
    /// <summary>
    /// No continue uri provided.
    /// </summary>
    public MissingContinueUriException() : base("´MISSING_CONTINUE_URI", "No continue uri provided.") { }
}