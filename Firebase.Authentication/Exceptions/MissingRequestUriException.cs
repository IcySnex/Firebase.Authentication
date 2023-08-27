namespace Firebase.Authentication.Exceptions;

public class MissingRequestUriException : IdentityPlatformException
{
    /// <summary>
    /// Third-party Auth Providers: Request does not contain a value for parameter: requestUri.
    /// </summary>
    public MissingRequestUriException() : base("Third-party Auth Providers: Request does not contain a value for parameter: requestUri.", "MISSING_REQUEST_URI") { }
}