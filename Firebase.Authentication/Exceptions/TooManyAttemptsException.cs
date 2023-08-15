namespace Firebase.Authentication.Exceptions;

public class TooManyAttemptsException : IdentityPlatformException
{
    /// <summary>
    /// We have blocked all requests from this device due to unusual activity. Try again later.
    /// </summary>
    public TooManyAttemptsException() : base("TOO_MANY_ATTEMPTS_TRY_LATER", "We have blocked all requests from this device due to unusual activity. Try again later.") { }
}