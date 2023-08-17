namespace Firebase.Authentication.Exceptions;

public class InvalidRequestTypeException : IdentityPlatformException
{
    /// <summary>
    /// The given request has an invalid type.
    /// </summary>
    public InvalidRequestTypeException() : base("INVALID_REQUEST_TYPE", "The given request has an invalid type.") { }
}