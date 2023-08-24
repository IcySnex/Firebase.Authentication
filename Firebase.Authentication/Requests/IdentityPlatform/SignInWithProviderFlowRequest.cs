using Firebase.Authentication.Client.Interfaces;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts:signInWithIDP with provider flow request
/// </summary>
public class SignInWithProviderFlowRequest : SignInRequest
{
    /// <summary>
    /// Creates a new SignInWithProviderFlowRequest
    /// </summary>
    /// <param name="flow">The provider flow used to sign in</param>
    public SignInWithProviderFlowRequest(
        IProviderFlow flow)
    {
        Flow = flow;
    }

    /// <summary>
    /// The provider flow used to sign in
    /// </summary>
    public IProviderFlow Flow { get; set; }
}