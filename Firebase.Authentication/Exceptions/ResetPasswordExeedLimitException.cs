namespace Firebase.Authentication.Exceptions;

public class ResetPasswordExeedLimitException : AuthenticationException
{
    /// <summary>
    /// Reset password limit exceeded.
    /// </summary>
    public ResetPasswordExeedLimitException() : base("RESET_PASSWORD_EXCEED_LIMIT", "Reset password limit exceeded.") { }
}