namespace Firebase.Authentication.Exceptions;

public class SystemErrorException : IdentityPlatformException
{
    /// <summary>
    /// A system error has occurred - missing or invalid postBody
    /// </summary>
    public SystemErrorException() : base("A system error has occurred - missing or invalid postBody", "SYSTEM_ERROR") { }
}