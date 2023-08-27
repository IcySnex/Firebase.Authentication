namespace Firebase.Authentication.Exceptions;

public class UserNotFoundException : IdentityPlatformException
{
    /// <summary>
    /// The user corresponding to the refresh token was not found. It is likely the user was deleted.
    /// </summary>
    public UserNotFoundException() : base("The user corresponding to the refresh token/identifier was not found. The user may have been deleted.", "USER_NOT_FOUND") { }
}