namespace Firebase.Authentication.Exceptions;

public class AdminOnlyOperationException : IdentityPlatformException
{
    /// <summary>
    /// This operation is for admins only.
    /// </summary>
    public AdminOnlyOperationException() : base("ADMIN_ONLY_OPERATION", "This operation is for admins only.") { }
}