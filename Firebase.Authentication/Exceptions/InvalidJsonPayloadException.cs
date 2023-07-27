namespace Firebase.Authentication.Exceptions;

public class InvalidJsonPayloadException : AuthenticationException
{
    /// <summary>
    /// Invalid JSON payload received. Unknown name \"refresh_tokens\": Cannot bind query parameter. Field 'refresh_tokens' could not be found in request message.
    /// </summary>
    public InvalidJsonPayloadException() : base("INVALID_PAYLOAD", "Invalid JSON payload received. Unknown name \"refresh_tokens\": Cannot bind query parameter. Field 'refresh_tokens' could not be found in request message.") { }
}