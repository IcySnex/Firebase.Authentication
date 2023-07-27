namespace Firebase.Authentication.Exceptions;

public class SystemErrorException : AuthenticationException
{
    /// <summary>
    /// A system error has occurred - missing or invalid postBody
    /// </summary>
    public SystemErrorException() : base("SYSTEM_ERROR", "A system error has occurred - missing or invalid postBody") { }
}