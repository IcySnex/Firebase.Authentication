using Firebase.Authentication.Client.Interfaces;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts:signInWithIDP with provider flow request
/// </summary>
public class LinkToProviderFlowRequest : LinkRequest
{
    /// <summary>
    /// Creates a new LinkToProviderFlowRequest
    /// </summary>
    /// <param name="flow">The provider flow used to link toparam>
    public LinkToProviderFlowRequest(
        IProviderFlow flow)
    {
        Flow = flow;
    }

    /// <summary>
    /// The provider flow used to sign in
    /// </summary>
    public IProviderFlow Flow { get; set; }
}