namespace Firebase.Authentication.Exceptions;

public class FederatedUserIdAlreadyLinkedException : IdentityPlatformException
{
    /// <summary>
    /// This credential is already associated with a different user account.
    /// </summary>
    public FederatedUserIdAlreadyLinkedException() : base("This credential is already associated with a different user account.", "FEDERATED_USER_ID_ALREADY_LINKED") { }
}