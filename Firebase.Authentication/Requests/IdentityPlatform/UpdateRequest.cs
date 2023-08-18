using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.update request
/// </summary>
public class UpdateRequest
{
    /// <summary>
    /// Creates a new UpdateRequest
    /// </summary>
    /// <param name="idToken">A valid Identity Platform ID token. Required when attempting to change user-related information</param>
    /// <param name="localId">The ID of the user</param>
    /// <param name="displayName">The user's new display name to be updated in the account's attributes</param>
    /// <param name="email">The user's new email to be updated in the account's attributes</param>
    /// <param name="password">The user's new password to be updated in the account's attributes</param>
    /// <param name="providers">The Identity Providers that the account should be associated with</param>
    /// <param name="oobCode">The out-of-band code to be applied on the user's account</param>
    /// <param name="emailVerified">Whether the user's email has been verified</param>
    /// <param name="upgradeToFederatedLogin">Whether the account should be restricted to only using federated login</param>
    /// <param name="captchaResponse">The response from reCaptcha challenge. This is required when the system detects possible abuse activities</param>
    /// <param name="validSince">Specifies the minimum timestamp in seconds for an Identity Platform ID token to be considered valid</param>
    /// <param name="disableUser">If true, marks the account as disabled, meaning the user will no longer be able to sign-in</param>
    /// <param name="photoUrl">The user's new photo URL for the account's profile photo to be updated in the account's attributes</param>
    /// <param name="deleteAttributes">The account's attributes to be deleted</param>
    /// <param name="returnSecureToken">Whether or not to return an ID and refresh token. Should always be true</param>
    /// <param name="deleteProviders">The Identity Providers to unlink from the user's account</param>
    /// <param name="lastLoginAt">The timestamp in milliseconds when the account last logged in</param>
    /// <param name="createdAt">The timestamp in milliseconds when the account was created</param>
    /// <param name="phoneNumber">The phone number to be updated in the account's attributes</param>
    /// <param name="customAttributes">JSON formatted custom attributes to be stored in the Identity Platform ID token</param>
    /// <param name="tenantId">The tenant ID of the Identity Platform tenant that the account belongs to</param>
    /// <param name="targetProjectId">The project ID for the project that the account belongs to</param>
    /// <param name="mfa">The multi-factor authentication related information to be set on the user's account</param>
    /// <param name="linkProviderInfo">The provider to be linked to the user's account</param>
    public UpdateRequest(
        string idToken,
        string? localId = null,
        string? displayName = null,
        string? email = null,
        string? password = null,
        Provider[]? providers = null,
        string? oobCode = null,
        bool? emailVerified = null,
        bool? upgradeToFederatedLogin = null,
        string? captchaResponse = null,
        long? validSince = null,
        bool? disableUser = null,
        string? photoUrl = null,
        UserAttributeName[]? deleteAttributes = null,
        bool? returnSecureToken = true,
        Provider[]? deleteProviders = null,
        long? lastLoginAt = null,
        long? createdAt = null,
        string? phoneNumber = null,
        string? customAttributes = null,
        string? tenantId = null,
        string? targetProjectId = null,
        MfaInfo? mfa = null,
        ProviderUserInfo? linkProviderInfo = null)
    {
        IdToken = idToken;
        LocalId = localId;
        DisplayName = displayName;
        Email = email;
        Password = password;
        Providers = providers;
        OobCode = oobCode;
        EmailVerified = emailVerified;
        UpgradeToFederatedLogin = upgradeToFederatedLogin;
        CaptchaResponse = captchaResponse;
        ValidSince = validSince;
        DisableUser = disableUser;
        PhotoUrl = photoUrl;
        DeleteAttributes = deleteAttributes;
        ReturnSecureToken = returnSecureToken;
        DeleteProviders = deleteProviders;
        LastLoginAt = lastLoginAt;
        CreatedAt = createdAt;
        PhoneNumber = phoneNumber;
        CustomAttributes = customAttributes;
        TenantId = tenantId;
        TargetProjectId = targetProjectId;
        Mfa = mfa;
        LinkProviderInfo = linkProviderInfo;
    }

    /// <summary>
    /// A valid Identity Platform ID token
    /// <br/>
    /// Required when attempting to change user-related information
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// The ID of the user
    /// </summary>
    [JsonPropertyName("localId")]
    public string? LocalId { get; set; }

    /// <summary>
    /// The user's new display name to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The user's new email to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The user's new password to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// The Identity Providers that the account should be associated with
    /// </summary>
    [JsonConverter(typeof(ProviderArrayJsonConverter))]
    [JsonPropertyName("provider")]
    public Provider[]? Providers { get; set; }

    /// <summary>
    /// The out-of-band code to be applied on the user's account
    /// </summary>
    [JsonPropertyName("oobCode")]
    public string? OobCode { get; set; }

    /// <summary>
    /// Whether the user's email has been verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool? EmailVerified { get; set; }

    /// <summary>
    /// Whether the account should be restricted to only using federated login
    /// </summary>
    [JsonPropertyName("upgradeToFederatedLogin")]
    public bool? UpgradeToFederatedLogin { get; set; }

    /// <summary>
    /// The response from reCaptcha challenge
    /// <br/>
    /// This is required when the system detects possible abuse activities
    /// </summary>
    [JsonPropertyName("captchaResponse")]
    public string? CaptchaResponse { get; set; }

    /// <summary>
    /// Specifies the minimum timestamp in seconds for an Identity Platform ID token to be considered valid
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
    [JsonPropertyName("validSince")]
    public long? ValidSince { get; set; }

    /// <summary>
    /// If true, marks the account as disabled, meaning the user will no longer be able to sign-in
    /// </summary>
    [JsonPropertyName("disableUser")]
    public bool? DisableUser { get; set; }

    /// <summary>
    /// The user's new photo URL for the account's profile photo to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string? PhotoUrl { get; set; }

    /// <summary>
    /// The account's attributes to be deleted
    /// </summary>
    [JsonConverter(typeof(UserAttributeNameListJsonConverter))]
    [JsonPropertyName("deleteAttribute")]
    public UserAttributeName[]? DeleteAttributes { get; set; }

    /// <summary>
    /// If true, marks the account as disabled, meaning the user will no longer be able to sign-in
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool? ReturnSecureToken { get; set; }

    /// <summary>
    /// The Identity Providers to unlink from the user's account
    /// </summary>
    [JsonConverter(typeof(ProviderArrayJsonConverter))]
    [JsonPropertyName("deleteProvider")]
    public Provider[]? DeleteProviders { get; set; }

    /// <summary>
    /// The timestamp in milliseconds when the account last logged in
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
    [JsonPropertyName("lastLoginAt")]
    public long? LastLoginAt { get; set; }

    /// <summary>
    /// The timestamp in milliseconds when the account last created
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>
    /// The phone number to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// JSON formatted custom attributes to be stored in the Identity Platform ID token
    /// </summary>
    [JsonPropertyName("customAttributes")]
    public string? CustomAttributes { get; set; }

    /// <summary>
    /// The tenant ID of the Identity Platform tenant that the account belongs to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// The project ID for the project that the account belongs to
    /// </summary>
    [JsonPropertyName("targetProjectId")]
    public string? TargetProjectId { get; set; }

    /// <summary>
    /// The multi-factor authentication related information to be set on the user's account
    /// </summary>
    [JsonPropertyName("mfa")]
    public MfaInfo? Mfa { get; set; }

    /// <summary>
    /// The provider to be linked to the user's account
    /// </summary>
    [JsonPropertyName("linkProviderUserInfo")]
    public ProviderUserInfo? LinkProviderInfo { get; set; }
}