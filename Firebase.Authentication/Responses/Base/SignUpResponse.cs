using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signUp response 
/// </summary>
public class SignUpResponse
{
    /// <summary>
    /// Creates a new SignUpResponse
    /// </summary>
    /// <param name="localId">The ID of the authenticated user</param>
    /// <param name="email">The email of the authenticated user</param>
    /// <param name="displayName">The created user's display name</param>
    /// <param name="idToken">An Identity Platform ID token for the created user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the created user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    [JsonConstructor]
    public SignUpResponse(
        string localId,
        string email,
        string displayName,
        string idToken,
        string refreshToken,
        TimeSpan expiresIn)
    {
        LocalId = localId;
        Email = email;
        DisplayName = displayName;
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The email of the authenticated user
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// The created user's display name
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

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
    public TimeSpan ExpiresIn { get; }
}