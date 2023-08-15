namespace Firebase.Authentication.Exceptions;

public class ExpiredOobCodeException : IdentityPlatformException
{
    /// <summary>
    /// The action code has expired.
    /// </summary>
    public ExpiredOobCodeException() : base("EXPIRED_OOB_CODE", "The action code has expired.") { }
}