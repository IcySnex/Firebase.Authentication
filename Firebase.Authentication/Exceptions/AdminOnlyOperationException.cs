namespace Firebase.Authentication.Exceptions;

public class AdminOnlyOperationException : IdentityPlatformException
{
    /// <summary>
    /// This operation is for admins only.
    /// </summary>
    public AdminOnlyOperationException() : base("This operation is for admins only.", "ADMIN_ONLY_OPERATION") { }
}