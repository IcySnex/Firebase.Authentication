namespace Firebase.Authentication.Exceptions;

public class OperationNotAllowedException : AuthenticationException
{
    /// <summary>
    /// The corresponding provider is disabled for this project.
    /// </summary>
    public OperationNotAllowedException() : base("OPERATION_NOT_ALLOWED", "The corresponding provider is disabled for this project.") { }
}