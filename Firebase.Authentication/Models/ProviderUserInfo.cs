using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Models;

/// <summary>
/// Model representing information about the user as provided by various Identity Providers
/// </summary>
public class ProviderUserInfo
{
    /// <summary>
    /// Creates a new ProviderUserInfo
    /// </summary>
    /// <param name="provider">The type of the Identity Provider</param>
    /// <param name="displayName">The user's display name at the Identity Provider</param>
    /// <param name="photoUrl">The user's profile photo URL at the Identity Provider</param>
    /// <param name="federatedId">The user's identifier at the Identity Provider</param>
    /// <param name="email">The user's email address at the Identity Provider</param>
    /// <param name="rawId">The user's raw identifier directly returned from Identity Provider</param>
    /// <param name="screenName">The user's screenName at Twitter or login name at GitHub</param>
    /// <param name="phoneNumber">The user's phone number at the Identity Provider</param>
    [JsonConstructor]
    public ProviderUserInfo(
        Provider provider,
        string displayName,
        string photoUrl,
        string federatedId,
        string email,
        string rawId,
        string screenName,
        string phoneNumber)
    {
        Provider = provider;
        DisplayName = displayName;
        PhotoUrl = photoUrl;
        FederatedId = federatedId;
        Email = email;
        RawId = rawId;
        ScreenName = screenName;
        PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// The type of the Identity Provider
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    public Provider Provider { get; }

    /// <summary>
    /// The user's display name at the Identity Provider
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// The user's profile photo URL at the Identity Provider
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string PhotoUrl { get; }

    /// <summary>
    /// The user's identifier at the Identity Provider
    /// </summary>
    [JsonPropertyName("federatedId")]
    public string FederatedId { get; }

    /// <summary>
    /// The user's email address at the Identity Provider
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// The user's raw identifier directly returned from Identity Provider
    /// </summary>
    [JsonPropertyName("rawId")]
    public string RawId { get; }

    /// <summary>
    /// The user's screenName at Twitter or login name at GitHub
    /// </summary>
    [JsonPropertyName("screenName")]
    public string ScreenName { get; }

    /// <summary>
    /// The user's phone number at the Identity Provider
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; }
}