using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.IdentityPlatform;

/// <summary>
/// Model to recieve a accounts.update response 
/// </summary>
public class UpdateResponse
{
    /// <summary>
    /// Creates a new UpdateResponse
    /// </summary>
    /// <param name="localId">The ID of the authenticated user</param>
    /// <param name="providerUserInfos">The linked Identity Providers on the account</param>
    /// <param name="newEmail">The new email that has been set on the user's account attributes</param>
    /// <param name="idToken">An Identity Platform ID token for the created user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the created user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    /// <param name="isEmailVerified">Whether the account's email has been verified</param>
    [JsonConstructor]
    public UpdateResponse(
        string localId,
        ProviderUserInfo[] providerUserInfos,
        string newEmail,
        string idToken,
        string refreshToken,
        TimeSpan? expiresIn,
        bool isEmailVerified)
    {
        LocalId = localId;
        ProviderUserInfos = providerUserInfos;
        NewEmail = newEmail;
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        IsEmailVerified = isEmailVerified;
    }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The linked Identity Providers on the account
    /// </summary>
    [JsonPropertyName("providerUserInfos")]
    public ProviderUserInfo[] ProviderUserInfos { get; }

    /// <summary>
    /// The new email that has been set on the user's account attributes
    /// </summary>
    [JsonPropertyName("newEmail")]
    public string NewEmail { get; }

    /// <summary>
    /// An Identity Platform ID token for the created user
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; }

    /// <summary>
    /// An Identity Platform refresh token for the created  user
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration timespan for the ID token
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("expiresIn")]
    public TimeSpan? ExpiresIn { get; }

    /// <summary>
    /// Whether the account's email has been verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool IsEmailVerified { get; }
}