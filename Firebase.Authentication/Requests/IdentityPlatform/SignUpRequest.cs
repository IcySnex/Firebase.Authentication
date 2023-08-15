using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.signUp request
/// </summary>
public class SignUpRequest : Requests.SignUpRequest
{
    /// <summary>
    /// Creates a new SignUpRequest
    /// </summary>
    /// <param name="email">The email for the user to create</param>
    /// <param name="password">The password for the user to create</param>
    /// <param name="displayName">The display name of the user to be created</param>
    /// <param name="photoUrl">The profile photo url of the user to create</param>
    /// <param name="phoneNumber">The phone number of the user to create</param>
    /// <param name="captchaResponse">The reCAPTCHA token provided by the reCAPTCHA client-side integration</param>
    /// <param name="idToken">A valid ID token for an Identity Platform user. If set, this request will link the authentication credential to the user represented by this ID token</param>
    /// <param name="isEmailVerified">Whether the user's email is verified</param>
    /// <param name="isDisabled">Whether the user will be disabled upon creation</param>
    /// <param name="localId">The ID of the user to create</param>
    /// <param name="returnSecureToken">Whether or not to return an ID and refresh token. Should always be true</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    /// <param name="targetProjectId">The project ID of the project which the user should belong to</param>
    /// <param name="mfaInfos">The multi-factor authentication providers for the user to create</param>
    public SignUpRequest(
        string? email = null,
        string? password = null,
        string? displayName = null,
        string? photoUrl = null,
        string? phoneNumber = null,
        string? captchaResponse = null,
        string? idToken = null,
        bool? isEmailVerified = null,
        bool? isDisabled = null,
        string? localId = null,
        bool returnSecureToken = true,
        string? tenantId = null,
        string? targetProjectId = null,
        MfaFactor[]? mfaInfos = null)
    {
        Email = email;
        Password = password;
        DisplayName = displayName;
        PhotoUrl = photoUrl;
        PhoneNumber = phoneNumber;
        CaptchaResponse = captchaResponse;
        IdToken = idToken;
        IsEmailVerified = isEmailVerified;
        IsDisabled = isDisabled;
        LocalId = localId;
        ReturnSecureToken = returnSecureToken;
        TenantId = tenantId;
        TargetProjectId = targetProjectId;
        MfaInfos = mfaInfos;
    }

    /// <summary>
    /// The email for the user to create
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The password for the user to create
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// The display name of the user to be created
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The profile photo url of the user to create
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string? PhotoUrl { get; set; }

    /// <summary>
    /// The phone number of the user to create
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The display name of the user to be created
    /// </summary>
    [JsonPropertyName("captchaResponse")]
    public string? CaptchaResponse { get; set; }

    /// <summary>
    /// A valid ID token for an Identity Platform user
    /// <br/>
    /// If set, this request will link the authentication credential to the user represented by this ID token
    /// </summary>
    [JsonPropertyName("idToken")]
    public string? IdToken { get; set; }

    /// <summary>
    /// Whether the user's email is verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool? IsEmailVerified { get; set; }

    /// <summary>
    /// Whether the user will be disabled upon creation
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? IsDisabled { get; set; }

    /// <summary>
    /// The ID of the user to create
    /// </summary>
    [JsonPropertyName("localId")]
    public string? LocalId { get; set; }

    /// <summary>
    /// Whether or not to return an ID and refresh token
    /// <br/>
    /// Should always be true
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// The project ID of the project which the user should belong to
    /// </summary>
    [JsonPropertyName("targetProjectId")]
    public string? TargetProjectId { get; set; }

    /// <summary>
    /// The multi-factor authentication providers for the user to create
    /// </summary>
    [JsonPropertyName("mfaInfo")]
    public MfaFactor[]? MfaInfos { get; set; }
}