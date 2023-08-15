namespace Firebase.Authentication.Exceptions;

public class MissingOrInvalidNonceException : IdentityPlatformException
{
    /// <summary>
    /// Duplicate credential received. Please try again with a new credential.
    /// </summary>
    public MissingOrInvalidNonceException() : base("MISSING_OR_INVALID_NONCE", "Duplicate credential received. Please try again with a new credential.") { }
}