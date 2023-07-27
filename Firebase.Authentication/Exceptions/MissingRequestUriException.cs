namespace Firebase.Authentication.Exceptions;

public class MissingRequestUriException : AuthenticationException
{
    /// <summary>
    /// Third-party Auth Providers: Request does not contain a value for parameter: requestUri.
    /// </summary>
    public MissingRequestUriException() : base("MISSING_REQUEST_URI", "Third-party Auth Providers: Request does not contain a value for parameter: requestUri.") { }
}