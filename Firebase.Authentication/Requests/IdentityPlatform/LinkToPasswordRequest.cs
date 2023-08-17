using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.update request
/// </summary>
public class LinkToPasswordRequest : LinkRequest
{
    /// <summary>
    /// Creates a new LinkToPasswordRequest
    /// </summary>
    /// <param name="idToken">A valid Identity Platform ID token</param>
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
    public LinkToPasswordRequest(
        string idToken,
        string email,
        string password,
        string? tenantId = null)
    {
        IdToken = idToken;
        Email = email;
        Password = password;
        TenantId = tenantId;
    }

    /// <summary>
    /// A valid Identity Platform ID token
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// The user's new email to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The user's new password to be updated in the account's attributes
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

    /// <summary>
    /// The tenant ID of the Identity Platform tenant that the account belongs to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}