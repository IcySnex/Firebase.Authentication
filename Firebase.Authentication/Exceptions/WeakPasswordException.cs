namespace Firebase.Authentication.Exceptions;

public class WeakPasswordException : IdentityPlatformException
{
    /// <summary>
    /// The password must be 6 characters long or more.
    /// </summary>
    public WeakPasswordException() : base("WEAK_PASSWORD", "The password must be 6 characters long or more.") { }
}