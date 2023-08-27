namespace Firebase.Authentication.Exceptions;

public class InvalidValueException : IdentityPlatformException
{
    /// <summary>
    /// Some value in the request was an invalid type.
    /// </summary>
    public InvalidValueException() : base("Some value in the request was an invalid type.", "INVALID_VALUE") { }
}