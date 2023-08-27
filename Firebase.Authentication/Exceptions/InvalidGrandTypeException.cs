namespace Firebase.Authentication.Exceptions;

public class InvalidGrandTypeException : IdentityPlatformException
{
    /// <summary>
    /// the grant type specified is invalid.
    /// </summary>
    public InvalidGrandTypeException() : base("the grant type specified is invalid.", "INVALID_GRANT_TYPE") { }
}