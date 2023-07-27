namespace Firebase.Authentication.Exceptions;

public class InvalidProviderIdException : AuthenticationException
{
    /// <summary>
    /// Third-party Auth Providers: PostBody does not contain or contains invalid Authentication Provider string.
    /// </summary>
    public InvalidProviderIdException() : base("INVALID_PROVIDER_ID : Provider Id is not supported.", "Third-party Auth Providers: PostBody does not contain or contains invalid Authentication Provider string.") { }
}