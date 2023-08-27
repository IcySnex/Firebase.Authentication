namespace Firebase.Authentication.Exceptions;

public class InvalidIdpResponseException : IdentityPlatformException
{
    /// <summary>
    /// The supplied auth credential is malformed or has expired.
    /// </summary>
    public InvalidIdpResponseException() : base("The supplied auth credential is malformed or has expired.", "INVALID_IDP_RESPONSE") { }
}