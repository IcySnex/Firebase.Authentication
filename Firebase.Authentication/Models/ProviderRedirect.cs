using Firebase.Authentication.Types;

namespace Firebase.Authentication.Models;

/// <summary>
/// Represents an authenticaion redirect at a provider
/// </summary>
public class ProviderRedirect
{
    /// <summary>
    /// Creates a new ProviderRedirect
    /// </summary>
    /// <param name="provider">The provider for the authenticaion request</param>
    /// <param name="uri">The authorization URI for the requested provider</param>
    /// <param name="sessionId"></param>
    public ProviderRedirect(
        Provider provider,
        string uri,
        string sessionId)
    {
        Provider = provider;
        Uri = uri;
        SessionId = sessionId;
    }


    /// <summary>
    /// The provider for the authenticaion request
    /// </summary>
    public Provider Provider { get; }

    /// <summary>
    /// The authorization URI for the requested provider
    /// </summary>
    public string Uri { get; }

    /// <summary>
    /// The session id for this authenticaion
    /// </summary>
    public string SessionId { get; }
}