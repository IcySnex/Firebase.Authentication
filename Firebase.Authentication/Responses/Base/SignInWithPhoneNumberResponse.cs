using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signInWithPhoneNumber response 
/// </summary>
public class SignInWithPhoneNumberResponse
{
    /// <summary>
    /// Creates a new SignInWithPhoneNumberResponse
    /// </summary>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the ID token</param>
    /// <param name="localId">The ID of the authenticated user</param>
    /// <param name="isNewUser">Whether the authenticated user was created by this request</param>
    /// <param name="temporaryProof">A proof of the phone number verification, provided if a phone authentication is successful but the user operation fails</param>
    /// <param name="phoneNumber">Phone number of the authenticated user</param>
    /// <param name="temporaryProofExpiresIn">The timespan until the temporary proof expires</param>
    [JsonConstructor]
    public SignInWithPhoneNumberResponse(
        string idToken,
        string refreshToken,
        TimeSpan expiresIn,
        string localId,
        bool isNewUser,
        string temporaryProof,
        string phoneNumber,
        TimeSpan temporaryProofExpiresIn)
    {
        IdToken = idToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        LocalId = localId;
        IsNewUser = isNewUser;
        TemporaryProof = temporaryProof;
        PhoneNumber = phoneNumber;
        TemporaryProofExpiresIn = temporaryProofExpiresIn;
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
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The email of the authenticated user
    /// </summary>
    [JsonPropertyName("isNewUser")]
    public bool IsNewUser { get; }

    /// <summary>
    /// A proof of the phone number verification, provided if a phone authentication is successful but the user operation fails
    /// </summary>
    [JsonPropertyName("temporaryProof")]
    public string TemporaryProof { get; }

    /// <summary>
    /// Phone number of the authenticated user
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; }

    /// <summary>
    /// The timespan until the temporary proof expires
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("temporaryProofExpiresIn")]
    public TimeSpan TemporaryProofExpiresIn { get; }
}