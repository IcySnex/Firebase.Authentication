using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signInWithEmailLink response
/// </summary>
public class SignInWithEmailLinkResponse
{
    /// <summary>
    /// Creates a new SignInWithEmailLinkResponse
    /// </summary>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="email">The email the user signed in with. Always present in the response</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the RefreshToken</param>
    /// <param name="localId">The ID of the authenticated user</param>
    /// <param name="isNewUser">Whether the authenticated user was created by this request</param>
    /// <param name="mfaPendingCredential">An opaque string that functions as proof that the user has successfully passed the first factor check</param>
    /// <param name="mfaInfos">Info on which multi-factor authentication providers are enabled. Present if the user needs to complete the sign-in using multi-factor authentication</param>
    [JsonConstructor]
    public SignInWithEmailLinkResponse(
        string idToken,
        string email,
        string refreshToken,
        TimeSpan expiresIn,
        string localId,
        bool isNewUser,
        string mfaPendingCredential,
        MfaEnrollment[] mfaInfos)
    {
        IdToken = idToken;
        Email = email;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        LocalId = localId;
        IsNewUser = isNewUser;
        MfaPendingCredential = mfaPendingCredential;
        MfaInfos = mfaInfos;
    }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; }

    /// <summary>
    /// The email the user signed in with. Always present in the response
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// An Identity Platform refresh token for the authenticated user
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; }

    /// <summary>
    /// The expiration timespan for the RefreshToken
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("expiresIn")]
    public TimeSpan ExpiresIn { get; }

    /// <summary>
    /// The ID of the authenticated user
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// Whether the authenticated user was created by this request
    /// </summary>
    [JsonPropertyName("isNewUser")]
    public bool IsNewUser { get; }

    /// <summary>
    /// An opaque string that functions as proof that the user has successfully passed the first factor check.
    /// </summary>
    [JsonPropertyName("mfaPendingCredential")]
    public string MfaPendingCredential { get; }

    /// <summary>
    /// Info on which multi-factor authentication providers are enabled
    /// <br/>
    /// Present if the user needs to complete the sign-in using multi-factor authentication
    /// </summary>
    [JsonPropertyName("mfaInfo")]
    public MfaEnrollment[] MfaInfos { get; }
}