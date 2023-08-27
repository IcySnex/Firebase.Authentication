namespace Firebase.Authentication.Exceptions;

public class ExpiredOobCodeException : IdentityPlatformException
{
    /// <summary>
    /// The action code has expired.
    /// </summary>
    public ExpiredOobCodeException() : base("The action code has expired.", "EXPIRED_OOB_CODE") { }
}