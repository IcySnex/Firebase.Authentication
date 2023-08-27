namespace Firebase.Authentication.Exceptions;

public class InvalidRequestTypeException : IdentityPlatformException
{
    /// <summary>
    /// The given request has an invalid type.
    /// </summary>
    public InvalidRequestTypeException() : base("The given request has an invalid type.", "INVALID_REQUEST_TYPE") { }
}