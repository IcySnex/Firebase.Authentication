#pragma warning disable CS0618 // PasswordHash, Salt: Type or member is obsolete

using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.signInWithIdp response
/// </summary>
public class SignInWithIdpResponse
{
    /// <summary>
    /// Creates a new SignInWithIdpResponse
    /// </summary>
    /// <param name="federatedId">The user's account ID at the IdP</param>
    /// <param name="provider">The provider of the IdP that the user is signing in to</param>
    /// <param name="email">The email address of the user's account at the IdP</param>
    /// <param name="isEmailVerified">Whether the account's email address has been verified</param>
    /// <param name="firstName">The first name for the user's account at the IdP</param>
    /// <param name="lastName">The last name for the user's account at the IdP</param>
    /// <param name="fullName">The full name for the user's account at the IdP</param>
    /// <param name="nickName">The nickname for the user's account at the IdP</param>
    /// <param name="language">The language preference for the user's account at the IdP</param>
    /// <param name="timeZone">The time zone for the user's account at the IdP</param>
    /// <param name="dateOfBirth">The date of birth for the user's account at the IdP</param>
    /// <param name="localId">The unique ID of the account</param>
    /// <param name="originalEmail">The main (top-level) email address of the user's Identity Platform account, if different from the email address at the IdP</param>
    /// <param name="isEmailRecycled">Whether or not there is an existing Identity Platform user account with the same email address but linked to a different account at the same IdP</param>
    /// <param name="displayName">The display name of the account</param>
    /// <param name="photoUrl">The URL of the account's profile photo</param>
    /// <param name="idToken">An Identity Platform ID token for the authenticated user</param>
    /// <param name="context">The opaque string set in accounts.createAuthUri that is used to maintain contextual information between the authentication request and the callback from the IdP</param>
    /// <param name="verifiedProviders">A list of providers that the user can sign in to in order to resolve a needConfirmation error</param>
    /// <param name="needConfirmation">Whether or not there is an existing Identity Platform user account with the same email address as the current account signed in at the IdP, and the account's email addresss is not verified at the IdP</param>
    /// <param name="oauthAccessToken">The OAuth access token from the IdP, if available</param>
    /// <param name="oauthRefreshToken">The OAuth 2.0 refresh token from the IdP, if available and returnRefreshToken is set to true</param>
    /// <param name="oauthExpireIn">The timesspan until the OAuth access token from the IdP expires</param>
    /// <param name="oauthAuthorizationCode">The OAuth 2.0 authorization code, if available. Only present for the Google provider</param>
    /// <param name="oauthTokenSecret">The OAuth 1.0 token secret from the IdP, if available. Only present for the Twitter provider</param>
    /// <param name="oauthIdToken">The OpenID Connect ID token from the IdP, if available</param>
    /// <param name="screenName">This account's screen name at Twitter or login name at GitHub</param>
    /// <param name="rawUserInfo">The stringified JSON response containing all the data corresponding to the user's account at the IdP</param>
    /// <param name="errorMessage">The error message returned if returnIdpCredential is set to true</param>
    /// <param name="isNewUser">Whether or not a new Identity Platform account was created for the authenticated user</param>
    /// <param name="pendingToken">An opaque string that can be used as a credential from the IdP the user is signing into</param>
    /// <param name="tenantId">The value of the tenantId field in the request</param>
    /// <param name="mfaPendingCredential">An opaque string that functions as proof that the user has successfully passed the first factor authentication</param>
    /// <param name="mfaInfos">Info on which multi-factor authentication providers are enabled for the account. Present if the user needs to complete the sign-in using multi-factor authentication</param>
    /// <param name="refreshToken">An Identity Platform refresh token for the authenticated user</param>
    /// <param name="expiresIn">The expiration timespan for the RefreshToken</param>
    [JsonConstructor]
    public SignInWithIdpResponse(
        string federatedId,
        Provider provider,
        string email,
        bool isEmailVerified,
        string firstName,
        string lastName,
        string fullName,
        string nickName,
        string language,
        string timeZone,
        string dateOfBirth,
        string localId,
        string originalEmail,
        bool isEmailRecycled,
        string displayName,
        string photoUrl,
        string idToken,
        string context,
        Provider[] verifiedProviders,
        bool needConfirmation,
        string oauthAccessToken,
        string oauthRefreshToken,
        TimeSpan oauthExpireIn,
        string oauthAuthorizationCode,
        string oauthTokenSecret,
        string oauthIdToken,
        string screenName,
        string rawUserInfo,
        string errorMessage,
        bool isNewUser,
        string pendingToken,
        string tenantId,
        string mfaPendingCredential,
        MfaEnrollment[] mfaInfos,
        string refreshToken,
        TimeSpan expiresIn)
    {
        FederatedId = federatedId;
        Provider = provider;
        Email = email;
        IsEmailVerified = isEmailVerified;
        FirstName = firstName;
        LastName = lastName;
        FullName = fullName;
        NickName = nickName;
        Language = language;
        TimeZone = timeZone;
        DateOfBirth = dateOfBirth;
        LocalId = localId;
        OriginalEmail = originalEmail;
        IsEmailRecycled = isEmailRecycled;
        DisplayName = displayName;
        PhotoUrl = photoUrl;
        IdToken = idToken;
        Context = context;
        VerifiedProviders = verifiedProviders;
        NeedConfirmation = needConfirmation;
        OauthAccessToken = oauthAccessToken;
        OauthRefreshToken = oauthRefreshToken;
        OauthExpireIn = oauthExpireIn;
        OauthAuthorizationCode = oauthAuthorizationCode;
        OauthTokenSecret = oauthTokenSecret;
        OauthIdToken = oauthIdToken;
        ScreenName = screenName;
        RawUserInfo = rawUserInfo;
        ErrorMessage = errorMessage;
        IsNewUser = isNewUser;
        PendingToken = pendingToken;
        TenantId = tenantId;
        MfaPendingCredential = mfaPendingCredential;
        MfaInfos = mfaInfos;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    /// <summary>
    /// The unique ID of the account
    /// </summary>
    [JsonPropertyName("federatedId")]
    public string FederatedId { get; }

    /// <summary>
    /// The provider ID of the IdP that the user is signing in to
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    public Provider Provider { get; }

    /// <summary>
    /// The email address of the user's account at the IdP
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// Whether the account's email address has been verified
    /// </summary>
    [JsonPropertyName("emailVerified")]
    public bool IsEmailVerified { get; }

    /// <summary>
    /// The first name for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; }

    /// <summary>
    /// The last name for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; }

    /// <summary>
    /// The full name for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("fullName")]
    public string FullName { get; }

    /// <summary>
    /// The nickname for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("nickName")]
    public string NickName { get; }

    /// <summary>
    /// The language preference for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; }

    /// <summary>
    /// The time zone for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("timeZone")]
    public string TimeZone { get; }

    /// <summary>
    /// The date of birth for the user's account at the IdP
    /// </summary>
    [JsonPropertyName("dateOfBirth")]
    public string DateOfBirth { get; }

    /// <summary>
    /// The unique ID of the account
    /// </summary>
    [JsonPropertyName("localId")]
    public string LocalId { get; }

    /// <summary>
    /// The main (top-level) email address of the user's Identity Platform account, if different from the email address at the IdP
    /// </summary>
    [JsonPropertyName("originalEmail")]
    public string OriginalEmail { get; }

    /// <summary>
    /// Whether or not there is an existing Identity Platform user account with the same email address but linked to a different account at the same IdP
    /// </summary>
    [JsonPropertyName("emailRecycled")]
    public bool IsEmailRecycled { get; }

    /// <summary>
    /// The display name of the account
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// The URL of the account's profile photo
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string PhotoUrl { get; }

    /// <summary>
    /// An Identity Platform ID token for the authenticated user
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; }

    /// <summary>
    /// The opaque string set in accounts.createAuthUri that is used to maintain contextual information between the authentication request and the callback from the IdP
    /// </summary>
    [JsonPropertyName("context")]
    public string Context { get; }

    /// <summary>
    /// A list of provider IDs that the user can sign in to in order to resolve a needConfirmation error
    /// </summary>
    [JsonConverter(typeof(ProviderArrayJsonConverter))]
    [JsonPropertyName("verifiedProvider")]
    public Provider[] VerifiedProviders { get; }

    /// <summary>
    /// Whether or not there is an existing Identity Platform user account with the same email address as the current account signed in at the IdP, and the account's email addresss is not verified at the IdP
    /// </summary>
    [JsonPropertyName("needConfirmation")]
    public bool NeedConfirmation { get; }

    /// <summary>
    /// The OAuth access token from the IdP, if available
    /// </summary>
    [JsonPropertyName("oauthAccessToken")]
    public string OauthAccessToken { get; }

    /// <summary>
    /// The OAuth 2.0 refresh token from the IdP, if available and returnRefreshToken is set to true
    /// </summary>
    [JsonPropertyName("oauthRefreshToken")]
    public string OauthRefreshToken { get; }

    /// <summary>
    /// The timespan until the OAuth access token from the IdP expires
    /// </summary>
    [JsonConverter(typeof(SecondsJsonConverter))]
    [JsonPropertyName("oauthExpireIn")]
    public TimeSpan OauthExpireIn { get; }

    /// <summary>
    /// The OAuth 2.0 authorization code, if available
    /// <br/>
    /// Only present for the Google provider
    /// </summary>
    [JsonPropertyName("oauthAuthorizationCode")]
    public string? OauthAuthorizationCode { get; }

    /// <summary>
    /// The OAuth 1.0 token secret from the IdP, if available. Only present for the Twitter provider
    /// </summary>
    [JsonPropertyName("oauthTokenSecret")]
    public string? OauthTokenSecret { get; }

    /// <summary>
    /// The OpenID Connect ID token from the IdP, if available
    /// </summary>
    [JsonPropertyName("oauthIdToken")]
    public string? OauthIdToken { get; }

    /// <summary>
    /// This account's screen name at Twitter or login name at GitHub
    /// </summary>
    [JsonPropertyName("screenName")]
    public string ScreenName { get; }

    /// <summary>
    /// The stringified JSON response containing all the data corresponding to the user's account at the IdP
    /// </summary>
    [JsonPropertyName("rawUserInfo")]
    public string RawUserInfo { get; }

    /// <summary>
    /// The error message returned if returnIdpCredential is set to true
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; }

    /// <summary>
    /// Whether or not a new Identity Platform account was created for the authenticated user
    /// </summary>
    [JsonPropertyName("isNewUser")]
    public bool IsNewUser { get; }

    /// <summary>
    /// An opaque string that can be used as a credential from the IdP the user is signing into
    /// </summary>
    [JsonPropertyName("pendingToken")]
    public string PendingToken { get; }

    /// <summary>
    /// The value of the tenantId field in the request
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string TenantId { get; }

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
}