using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a securetoken.token response 
/// </summary>
public class SecureTokenResponse
{
    /// <summary>
    /// Creates a new SecureTokenResponse
    /// </summary>
    /// <param name="tokenType">The type of the refresh token, always "Bearer".</param>
    /// <param name="idToken">An Identity Platform ID token for the created user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the created user</param>
    /// <param name="expiresIn">The expiration timespan for the RefreshToken</param>
    /// <param name="userId">The uid corresponding to the provided ID token</param>
    /// <param name="projectId">The Firebase project ID</param>
    [JsonConstructor]
    public SecureTokenResponse(
        string tokenType,
        string idToken,
        string refreshToken,
        TimeSpan expiresIn,
        string userId,
        string projectId)
    {
        TokenType = tokenType;
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        UserId = userId;
        ProjectId = projectId;
    }

    /// <summary>
    /// The type of the refresh token, always "Bearer"
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; }

    /// <summary>
    /// An Identity Platform ID token
    /// </summary>
    [JsonPropertyName("id_token")]
    public string IdToken { get; }

    /// <summary>
    /// An Identity Platform refresh token provided in the request or a new refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration timespan for the RefreshToken
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("expires_in")]
    public TimeSpan ExpiresIn { get; }

    /// <summary>
    /// The uid corresponding to the provided ID token
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; }

    /// <summary>
    /// The Firebase project ID
    /// </summary>
    [JsonPropertyName("project_id")]
    public string ProjectId { get; }
}