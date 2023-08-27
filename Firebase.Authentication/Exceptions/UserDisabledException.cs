namespace Firebase.Authentication.Exceptions;

public class UserDisabledException : IdentityPlatformException
{
    /// <summary>
    /// The user account has been disabled by an administrator.
    /// </summary>
    public UserDisabledException() : base("The user account has been disabled by an administrator.", "USER_DISABLED") { }
}