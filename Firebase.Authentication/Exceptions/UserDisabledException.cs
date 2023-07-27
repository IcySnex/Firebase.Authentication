namespace Firebase.Authentication.Exceptions;

public class UserDisabledException : AuthenticationException
{
    /// <summary>
    /// The user account has been disabled by an administrator.
    /// </summary>
    public UserDisabledException() : base("USER_DISABLED", "The user account has been disabled by an administrator.") { }
}