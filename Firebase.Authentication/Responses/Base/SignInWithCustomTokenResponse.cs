using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signInWithCustomToken response 
/// </summary>
public class SignInWithCustomTokenResponse
{
    /// <summary>
    /// Creates a new SignInWithCustomTokenResponse
    /// </summary>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    /// <param name="isNewUser">Whether the authenticated user was created by this request</param>
    [JsonConstructor]
    public SignInWithCustomTokenResponse(
        string idToken,
        string refreshToken,
        TimeSpan expiresIn,
        bool isNewUser)
    {
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        IsNewUser = isNewUser;
    }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; }

    /// <summary>
    /// An Identity Platform refresh token for the authenticated user
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration timespan for the ID token
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("expiresIn")]
    public TimeSpan ExpiresIn { get; }

    /// <summary>
    /// Whether the authenticated user was created by this request
    /// </summary>
    [JsonPropertyName("isNewUser")]
    public bool IsNewUser { get; }
}