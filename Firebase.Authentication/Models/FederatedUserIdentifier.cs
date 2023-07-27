using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Models;

/// <summary>
/// Model representing a federated user identifier at an Identity Provider
/// </summary>
public class FederatedUserIdentifier
{
    /// <summary>
    /// Creates a new FederatedUserIdentifier
    /// </summary>
    /// <param name="provider">The supported identity providers</param>
    /// <param name="rawId">The user ID of the account at the third-party Identity Provider specified by providerId</param>
    [JsonConstructor]
    public FederatedUserIdentifier(
        Provider provider,
        string rawId)
    {
        Provider = provider;
        RawId = rawId;
    }

    /// <summary>
    /// The supported identity providers
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    public Provider Provider { get; }

    /// <summary>
    /// The user ID of the account at the third-party Identity Provider specified by provider
    /// </summary>
    [JsonPropertyName("rawId")]
    public string RawId { get; }
}