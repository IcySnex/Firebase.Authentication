namespace Firebase.Authentication.Exceptions;

public class InvalidJsonPayloadException : IdentityPlatformException
{
    /// <summary>
    /// Invalid JSON payload received. Unknown name \"\": Cannot bind query parameter.
    /// </summary>
    public InvalidJsonPayloadException() : base("INVALID_PAYLOAD", "Invalid JSON payload received. Unknown name \"\": Cannot bind query parameter.") { }
}