namespace Firebase.Authentication.Exceptions;

public class InvalidOobCodeException : IdentityPlatformException
{
    /// <summary>
    /// The action code is invalid. This can happen if the code is malformed, expired, or has already been used.
    /// </summary>
    public InvalidOobCodeException() : base("The action code is invalid. This can happen if the code is malformed, expired, or has already been used.", "INVALID_OOB_CODE") { }
}