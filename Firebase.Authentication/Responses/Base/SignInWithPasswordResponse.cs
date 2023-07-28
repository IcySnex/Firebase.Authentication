using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signInWithPassword response 
/// </summary>
public class SignInWithPasswordResponse
{
    /// <summary>
    /// Creates a new SignInWithPasswordResponse
    /// </summary>
    /// <param name="localId">The ID of the authenticated user</param>
    /// <param name="email">The email of the authenticated user</param>
    /// <param name="displayName">The user's display name stored in the account's attributes</param>
    /// <param name="profilePicture">The user's profile picture stored in the account's attributes</param>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    /// <param name="mfaPendingCredential">An opaque string that functions as proof that the user has successfully passed the first factor authentication</param>
    /// <param name="mfaInfos">Info on which multi-factor authentication providers are enabled for the account. Present if the user needs to complete the sign-in using multi-factor authentication</param>
    [JsonConstructor]
    public SignInWithPasswordResponse(
        string localId,
        string email,
        string displayName,
        string profilePicture,
        string idToken,
        string refreshToken,
        TimeSpan expiresIn,
        string mfaPendingCredential,
        MfaEnrollment[] mfaInfos)
    {
        LocalId = localId;
        Email = email;
        DisplayName = displayName;
        IdToken = idToken;
        ProfilePicture = profilePicture;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        MfaPendingCredential = mfaPendingCredential;
        MfaInfos = mfaInfos;
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
    /// The user's display name stored in the account's attributes
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// The user's profile picture stored in the account's attributes
    /// </summary>
    [JsonPropertyName("profilePicture")]
    public string ProfilePicture { get; }

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
    /// An opaque string that functions as proof that the user has successfully passed the first factor authentication
    /// </summary>
    [JsonPropertyName("mfaPendingCredential")]
    public string MfaPendingCredential { get; }

    /// <summary>
    /// Info on which multi-factor authentication providers are enabled for the account
    /// <br/>
    /// Present if the user needs to complete the sign-in using multi-factor authentication
    /// </summary>
    [JsonPropertyName("mfaInfo")]
    public MfaEnrollment[]? MfaInfos { get; }
}