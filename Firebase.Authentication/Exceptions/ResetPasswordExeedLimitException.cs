namespace Firebase.Authentication.Exceptions;

public class ResetPasswordExeedLimitException : IdentityPlatformException
{
    /// <summary>
    /// Reset password limit exceeded.
    /// </summary>
    public ResetPasswordExeedLimitException() : base("Reset password limit exceeded.", "RESET_PASSWORD_EXCEED_LIMIT") { }
}