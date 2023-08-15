namespace Firebase.Authentication.Exceptions;

public class UserNotFoundException : IdentityPlatformException
{
    /// <summary>
    /// The user corresponding to the refresh token was not found. It is likely the user was deleted.
    /// </summary>
    public UserNotFoundException() : base("USER_NOT_FOUND", "The user corresponding to the refresh token/identifier was not found. The user may have been deleted.") { }
}