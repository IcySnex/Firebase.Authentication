namespace Firebase.Authentication.Exceptions;

public class MissingContinueUriException : IdentityPlatformException
{
    /// <summary>
    /// No continue uri provided.
    /// </summary>
    public MissingContinueUriException() : base("No continue uri provided.", "´MISSING_CONTINUE_URI") { }
}