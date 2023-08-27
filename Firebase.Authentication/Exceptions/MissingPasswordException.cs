namespace Firebase.Authentication.Exceptions;

public class MissingPasswordException : IdentityPlatformException
{
    /// <summary>
    /// No password provided.
    /// </summary>
    public MissingPasswordException() : base("No password provided.", "MISSING_PASSWORD") { }
}