using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a securetoken.token request
/// </summary>
public class SecureTokenRequest
{
    /// <summary>
    /// Creates a new SecureTokenRequest
    /// </summary>
    /// <param name="refreshToken">A Firebase Auth refresh token</param>
    /// <param name="grantType">The refresh token's grant type, always "refresh_token"</param>
    public SecureTokenRequest(
        string refreshToken,
        GrantType grantType = GrantType.RefreshToken)
    {
        RefreshToken = refreshToken;
        GrantType = grantType;
    }

    /// <summary>
    /// A Firebase Auth refresh token
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// The refresh token's grant type, always "refresh_token"
    /// </summary>
    [JsonPropertyName("grant_type")]
    [JsonConverter(typeof(GrantTypeJsonConverter))]
    public GrantType GrantType { get; set; }
}