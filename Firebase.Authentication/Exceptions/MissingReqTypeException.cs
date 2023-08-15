namespace Firebase.Authentication.Exceptions;

public class MissingReqTypeException : IdentityPlatformException
{
    /// <summary>
    /// Request does not contain a value for parameter: requestType or supplied value is invalid.
    /// </summary>
    public MissingReqTypeException() : base("MISSING_REQ_TYPE", "Request does not contain a value for parameter: requestType or supplied value is invalid.") { }
}