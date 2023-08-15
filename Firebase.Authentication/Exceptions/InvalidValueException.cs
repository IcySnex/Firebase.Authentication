namespace Firebase.Authentication.Exceptions;

public class InvalidValueException : IdentityPlatformException
{
    /// <summary>
    /// Some value in the request was an invalid type.
    /// </summary>
    public InvalidValueException() : base("INVALID_VALUE", "Some value in the request was an invalid type.") { }
}