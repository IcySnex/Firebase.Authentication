using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.signInWithPhoneNumber request
/// </summary>
public class LinkToPhoneNumberRequest : LinkRequest
{
    /// <summary>
    /// Creates a new LinkToPhoneNumberRequest
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information from the response of sendVerificationCode</param>
    /// <param name="phoneNumber">The user's phone number to sign in with</param>
    /// <param name="code">User-entered verification code from an SMS sent to the user's phone</param>
    /// <param name="temporaryProof">A proof of the phone number verification, provided from a previous signInWithPhoneNumber request</param>
    /// <param name="idToken">A valid ID token for an Identity Platform account. If passed, this request will link the phone number to the user represented by this ID token</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    public LinkToPhoneNumberRequest(
        string idToken,
        string? sessionInfo = null,
        string? phoneNumber = null,
        string? code = null,
        string? temporaryProof = null,
        string? tenantId = null)
    {
        SessionInfo = sessionInfo;
        IdToken = idToken;
        PhoneNumber = phoneNumber;
        Code = code;
        TemporaryProof = temporaryProof;
        IdToken = idToken;
        TenantId = tenantId;
    }

    /// <summary>
    /// A valid ID token for an Identity Platform account
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// Encrypted session information from the response of sendVerificationCode
    /// </summary>
    [JsonPropertyName("sessionInfo")]
    public string? SessionInfo { get; set; }

    /// <summary>
    /// The user's phone number to sign in with
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// User-entered verification code from an SMS sent to the user's phone
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// A proof of the phone number verification, provided from a previous signInWithPhoneNumber request
    /// </summary>
    [JsonPropertyName("temporaryProof")]
    public string? TemporaryProof { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}