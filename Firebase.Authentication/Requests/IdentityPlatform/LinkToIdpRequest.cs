using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.signInWithIdp request
/// </summary>
public class LinkToIdpRequest : LinkRequest
{
    /// <summary>
    /// Creates a new LinkToIdpRequest
    /// </summary>
    /// <param name="requestUri">The URL to which the IdP redirects the user back</param>
    /// <param name="sessionId">The session ID returned from a previous accounts.createAuthUri call</param>
    /// <param name="postBody">The body of the HTTP POST callback from the IdP, if present</param>
    /// <param name="idToken">A valid Identity Platform ID token. If passed, the user's account at the IdP will be linked to the account represented by this ID token</param>
    /// <param name="returnRefreshToken">Whether or not to return the OAuth refresh token from the IdP, if available</param>
    /// <param name="returnIdpCredential">Whether or not to return OAuth credentials from the IdP on the following errors: FEDERATED_USER_ID_ALREADY_LINKED and EMAIL_EXISTS</param>
    /// <param name="returnSecureToken">Whether or not to return an ID and refresh token. Should always be true</param>
    /// <param name="captchaResponse">The reCAPTCHA token provided by the reCAPTCHA client-side integration</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    /// <param name="pendingToken">An opaque string from a previous accounts.signInWithIdp response</param>
    public LinkToIdpRequest(
        string requestUri,
        string sessionId,
        string idToken,
        string? postBody = null,
        bool returnRefreshToken = true,
        bool returnIdpCredential = true,
        bool returnSecureToken = true,
        string? captchaResponse = null,
        string? tenantId = null,
        string? pendingToken = null)
    {
        RequestUri = requestUri;
        PostBody = postBody;
        SessionId = sessionId;
        IdToken = idToken;
        ReturnSecureToken = returnRefreshToken;
        ReturnIdpCredential = returnIdpCredential;
        ReturnSecureToken = returnSecureToken;
        CaptchaResponse = captchaResponse;
        TenantId = tenantId;
        PendingToken = pendingToken;
    }

    /// <summary>
    /// The URL to which the IdP redirects the user back
    /// </summary>
    [JsonPropertyName("requestUri")]
    public string RequestUri { get; set; }

    /// <summary>
    /// The session ID returned from a previous accounts.createAuthUri call
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; }

    /// <summary>
    /// A valid Identity Platform ID token
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// The body of the HTTP POST callback from the IdP, if present
    /// </summary>
    [JsonPropertyName("postBody")]
    public string? PostBody { get; set; }

    /// <summary>
    /// Whether or not to return the OAuth refresh token from the IdP, if available
    /// </summary>
    [JsonPropertyName("returnRefreshToken")]
    public bool ReturnRefreshToken { get; set; }

    /// <summary>
    /// Whether or not to return OAuth credentials from the IdP on the following errors: <see cref="FederatedUserIdAlreadyLinkedException"/> and <see cref="EmailExistsException"/>
    /// </summary>
    [JsonPropertyName("returnIdpCredential")]
    public bool ReturnIdpCredential { get; set; }

    /// <summary>
    /// Whether or not to return an ID and refresh token
    /// <br/>
    /// Should always be true
    /// </summary>
    [JsonPropertyName("returnSecureToken")]
    public bool ReturnSecureToken { get; set; }

    /// <summary>
    /// The reCAPTCHA token provided by the reCAPTCHA client-side integration
    /// </summary>
    [JsonPropertyName("captchaResponse")]
    public string? CaptchaResponse { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// An opaque string from a previous accounts.signInWithIdp response
    /// </summary>
    [JsonPropertyName("pendingToken")]
    public string? PendingToken { get; set; }
}