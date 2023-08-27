namespace Firebase.Authentication.Exceptions;

public class MissingReqTypeException : IdentityPlatformException
{
    /// <summary>
    /// Request does not contain a value for parameter: requestType or supplied value is invalid.
    /// </summary>
    public MissingReqTypeException() : base("Request does not contain a value for parameter: requestType or supplied value is invalid.", "MISSING_REQ_TYPE") { }
}