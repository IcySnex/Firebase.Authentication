#pragma warning disable CS0618 // PasswordHash, Salt: Type or member is obsolete

using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Models;

/// <summary>
/// Model representing an Identity Platform account's information
/// </summary>
public class UserInfo
{
    /// <summary>
    /// Creates a new UserInfo
    /// </summary>
    /// <param name="localId">The unique ID of the account</param>
    /// <param name="email">The account's email address</param>
    /// <param name="displayName">The display name of the account</param>
    /// <param name="language">The language preference of the account</param>
    /// <param name="photoUrl">The URL of the account's profile photo</param>
    /// <param name="timeZone">The time zone preference of the account</param>
    /// <param name="dateOfBirth">The date of birth set for the account</param>
    /// <param name="passwordHash">The password hash of this user</param>
    /// <param name="salt">The account's password salt</param>
    /// <param name="version">The version of the account's password</param>
    /// <param name="isEmailVerified">Whether the account's email address has been verified</param>
    /// <param name="passwordUpdatedAt">The date and time when the password of this user last got updated</param>
    /// <param name="providerUserInfos">Information about the user as provided by various Identity Providers</param>
    /// <param name="validSince">The date and time when this user is valid</param>
    /// <param name="isDisabled">Whether the account is disabled</param>
    /// <param name="lastLoginAt">The date and time when this user last logged in</param>
    /// <param name="createdAt">The date and time when this user was created at</param>
    /// <param name="screenName">This account's screen name at Twitter or login name at GitHub</param>
    /// <param name="isCustomAuth">Whether this account has been authenticated using accounts.signInWithCustomToken</param>
    /// <param name="phoneNumber">The account's phone number</param>
    /// <param name="customAttributes">Custom claims to be added to any ID tokens minted for the account (JSON)</param>
    /// <param name="isEmailLinkSignin">Whether the account can authenticate with email link</param>
    /// <param name="tenantId">ID of the tenant this account belongs to</param>
    /// <param name="mfaInfos">Information on which multi-factor authentication providers are enabled for this account</param>
    /// <param name="initialEmail">The first email address associated with this account</param>
    /// <param name="lastRefreshAt">The date and time when an ID token was last minted for this account</param>
    [JsonConstructor]
    public UserInfo(string localId,
        string email,
        string displayName,
        string language,
        string photoUrl,
        string timeZone,
        string dateOfBirth,
        string passwordHash,
        string salt,
        int version,
        bool isEmailVerified,
        DateTime passwordUpdatedAt,
        ProviderUserInfo[] providerUserInfos,
        DateTime validSince,
        bool isDisabled,
        DateTime lastLoginAt,
        string createdAt,
        string screenName,
        bool isCustomAuth,
        string phoneNumber,
        string customAttributes,
        bool isEmailLinkSignin,
        string tenantId,
        MfaEnrollment[] mfaInfos,
        string initialEmail,
        DateTime lastRefreshAt,
        TimeSpan? validityPeriod = null)
    {
        LocalId = localId;
        Email = email;
        DisplayName = displayName;
        Language = language;
        PhotoUrl = photoUrl;
        TimeZone = timeZone;
        DateOfBirth = dateOfBirth;
        PasswordHash = passwordHash;
        Salt = salt;
        Version = version;
        IsEmailVerified = isEmailVerified;
        PasswordUpdatedAt = passwordUpdatedAt;
        ProviderUserInfos = providerUserInfos;
        ValidSince = validSince;
        IsDisabled = isDisabled;
        LastLoginAt = lastLoginAt;
        CreatedAt = createdAt;
        ScreenName = screenName;
        IsCustomAuth = isCustomAuth;
        PhoneNumber = phoneNumber;
        CustomAttributes = customAttributes;
        IsEmailLinkSignin = isEmailLinkSignin;
        TenantId = tenantId;
        MfaInfos = mfaInfos;
        InitialEmail = initialEmail;
        LastRefreshAt = lastRefreshAt;
        ValidityPeriod = validityPeriod;
    }


    /// <summary>
    /// The unique ID of the account
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The account's email address
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// The display name of the account
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// The language preference of the account
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; }

    /// <summary>
    /// The URL of the account's profile photo
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string PhotoUrl { get; }

    /// <summary>
    /// The time zone preference of the account
    /// </summary>
    [JsonPropertyName("timeZone")]
    public string TimeZone { get; }

    /// <summary>
    /// The date of birth set for the account
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string DateOfBirth { get; }

    /// <summary>
    /// The password hash of this user
    /// </summary>
    [Obsolete("Showing passwords in your application may be dangerous! (Even if its hashed)")]
    [JsonPropertyName("passwordHash")]
    public string PasswordHash { get; }

    /// <summary>
    /// The account's password salt
    /// </summary>
    [Obsolete("Showing salts in your application may be dangerous! (Even if its hashed)")]
    [JsonPropertyName("salt")]
    public string Salt { get; }

    /// <summary>
    /// The version of the account's password
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; }

    /// <summary>
    /// Whether the account's email address has been verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool IsEmailVerified { get; }

    /// <summary>
    /// The date and time when the password of this user last got updated
    /// </summary>
    [JsonConverter(typeof(MsJsonConverter))]
    [JsonPropertyName("passwordUpdatedAt")]
    public DateTime PasswordUpdatedAt { get; }

    /// <summary>
    /// Information about the user as provided by various Identity Providers
    /// </summary>
    [JsonPropertyName("providerUserInfo")]
    public ProviderUserInfo[] ProviderUserInfos { get; }

    /// <summary>
    /// The date and time when this user is valid
    /// </summary>
    [JsonConverter(typeof(SStringJsonConverter))]
    [JsonPropertyName("validSince")]
    public DateTime ValidSince { get; }

    /// <summary>
    /// Whether the account is disabled
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool IsDisabled { get; }

    /// <summary>
    /// The date and time when this user last logged in
    /// </summary>
    [JsonConverter(typeof(MsStringJsonConverter))]
    [JsonPropertyName("lastLoginAt")]
    public DateTime LastLoginAt { get; }

    /// <summary>
    /// The date and time when this user was created at
    /// </summary>
    [JsonConverter(typeof(MsStringJsonConverter))]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; }

    /// <summary>
    /// This account's screen name at Twitter or login name at GitHub
    /// </summary>
    [JsonPropertyName("screenName")]
    public string ScreenName { get; }

    /// <summary>
    /// Whether this account has been authenticated using accounts.signInWithCustomToken
    /// </summary>
    [JsonPropertyName("customAuth")]
    public bool IsCustomAuth { get; }

    /// <summary>
    /// The account's phone number
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; }

    /// <summary>
    /// Custom claims to be added to any ID tokens minted for the account (JSON)
    /// </summary>
    [JsonPropertyName("customAttributes")]
    public string CustomAttributes { get; }

    /// <summary>
    /// Custom claims to be added to any ID tokens minted for the account (JSON)
    /// </summary>
    [JsonPropertyName("emailLinkSignin")]
    public bool IsEmailLinkSignin { get; }

    /// <summary>
    /// ID of the tenant this account belongs to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string TenantId { get; }

    /// <summary>
    /// Information on which multi-factor authentication providers are enabled for this account
    /// </summary>
    [JsonPropertyName("mfaInfo")]
    public MfaEnrollment[] MfaInfos { get; }

    /// <summary>
    /// The first email address associated with this account
    /// </summary>
    [JsonPropertyName("initialEmail")]
    public string InitialEmail { get; }

    /// <summary>
    /// The date and time when an ID token was last minted for this account
    /// </summary>
    [JsonPropertyName("lastRefreshAt")]
    public DateTime LastRefreshAt { get; }


    /// <summary>
    /// The time span at which the user should be refreshed to maintain up-to-date information. Null if it should never expire
    /// </summary>
    public TimeSpan? ValidityPeriod { get; set; }

    /// <summary>
    /// The date and time when this user request was recieved
    /// </summary>
    public DateTime Recieved { get; } = DateTime.Now;

    /// <summary>
    /// A boolean weither the user should be refreshed to maintain up-to-date information
    /// </summary>
    public bool IsValid =>
        ValidityPeriod.HasValue ? DateTime.Now < Recieved.Add(ValidityPeriod.Value) : true;
}