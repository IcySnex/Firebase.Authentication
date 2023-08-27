namespace Firebase.Authentication.Exceptions;

public class InvalidProviderIdException : IdentityPlatformException
{
    /// <summary>
    /// Third-party Auth Providers: PostBody does not contain or contains invalid Authentication Provider string.
    /// </summary>
    public InvalidProviderIdException() : base("Third-party Auth Providers: PostBody does not contain or contains invalid Authentication Provider string.", "INVALID_PROVIDER_ID : Provider Id is not supported.") { }
}