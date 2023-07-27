using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.Base;

/// <summary>
/// Model to send a accounts.ignInWithCustomToken request
/// </summary>
public class SignInWithCustomTokenRequest
{
    /// <summary>
    /// Creates a new SignInWithCustomTokenRequest
    /// </summary>
    /// <param name="token">A Firebase Auth custom token from which to create an ID and refresh token pair</param>
    /// <param name="returnSecureToken">Whether or not to return an ID and refresh token. Should always be true</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    public SignInWithCustomTokenRequest(
        string token,
        bool returnSecureToken = true,
        string? tenantId = null)
    {
        Token = token;
        ReturnSecureToken = returnSecureToken;
        TenantId = tenantId;
    }

    /// <summary>
    /// A Firebase Auth custom token from which to create an ID and refresh token pair
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    /// Whether or not to return an ID and refresh token. Should always be true
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}