namespace Firebase.Authentication.Exceptions;

public class OperationNotAllowedException : IdentityPlatformException
{
    /// <summary>
    /// The corresponding provider is disabled for this project.
    /// </summary>
    public OperationNotAllowedException() : base("The corresponding provider is disabled for this project.", "OPERATION_NOT_ALLOWED") { }
}