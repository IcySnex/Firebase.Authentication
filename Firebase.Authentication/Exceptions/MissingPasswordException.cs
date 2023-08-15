namespace Firebase.Authentication.Exceptions;

public class MissingPasswordException : IdentityPlatformException
{
    /// <summary>
    /// No password provided.
    /// </summary>
    public MissingPasswordException() : base("MISSING_PASSWORD", "No password provided.") { }
}