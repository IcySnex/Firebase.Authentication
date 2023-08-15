using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a createAuthUri request
/// </summary>
public class CreateAuthUriRequest
{
    /// <summary>
    /// Creates a new CreateAuthUriRequest
    /// </summary>
    /// <param name="identifier">The email identifier of the user account to fetch associated providers for.</param>
    /// <param name="continueUri">A valid URL for the IdP to redirect the user back to.</param>
    /// <param name="provider">The provider of the IdP for the user to sign in with.</param>
    /// <param name="oauthScopes">Additional space-delimited OAuth 2.0 scopes specifying the scope of the authentication request with the IdP.</param>
    /// <param name="context">An opaque string used to maintain contextual information between the authentication request and the callback from the IdP.</param>
    /// <param name="hostedDomain">Used for the Google provider. The G Suite hosted domain of the user in order to restrict sign-in to users at that domain.</param>
    /// <param name="sessionId">A session ID that can be verified against in accounts.signInWithIdp to prevent session fixation attacks.</param>
    /// <param name="authFlowType">Used for the Google provider. The type of the authentication flow to be used.</param>
    /// <param name="customParameter">Additional customized query parameters to be added to the authorization URI.</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant to create an authorization URI or lookup an email identifier for.</param>
    public CreateAuthUriRequest(
        string continueUri,
        string? identifier = null,
        Provider? provider = null,
        string[]? oauthScopes = null,
        string? context = null,
        string? hostedDomain = null,
        string? sessionId = null,
        string? authFlowType = null,
        string? customParameter = null,
        string? tenantId = null)
    {
        Identifier = identifier;
        ContinueUri = continueUri;
        Provider = provider;
        OauthScopes = oauthScopes;
        Context = context;
        HostedDomain = hostedDomain;
        SessionId = sessionId;
        AuthFlowType = authFlowType;
        CustomParameter = customParameter;
        TenantId = tenantId;
    }

    /// <summary>
    /// A valid URL for the IdP to redirect the user back to.
    /// </summary>
    [JsonPropertyName("continueUri")]
    public string ContinueUri { get; set; }

    /// <summary>
    /// The email identifier of the user account to fetch associated providers for.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// The provider of the IdP for the user to sign in with.
    /// </summary>
    [JsonConverter(typeof(ProviderJsonConverter))]
    [JsonPropertyName("providerId")]
    public Provider? Provider { get; set; }

    /// <summary>
    /// Additional space-delimited OAuth 2.0 scopes specifying the scope of the authentication request with the IdP.
    /// </summary>
    [JsonConverter(typeof(ArrayStringConverter))]
    [JsonPropertyName("oauthScopes")]
    public string[]? OauthScopes { get; set; }

    /// <summary>
    /// An opaque string used to maintain contextual information between the authentication request and the callback from the IdP.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// Used for the Google provider. The G Suite hosted domain of the user in order to restrict sign-in to users at that domain.
    /// </summary>
    [JsonPropertyName("hostedDomain")]
    public string? HostedDomain { get; set; }

    /// <summary>
    /// A session ID that can be verified against in accounts.signInWithIdp to prevent session fixation attacks.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    /// <summary>
    /// Used for the Google provider. The type of the authentication flow to be used.
    /// </summary>
    [JsonPropertyName("authFlowType")]
    public string? AuthFlowType { get; set; }

    /// <summary>
    /// Additional customized query parameters to be added to the authorization URI.
    /// </summary>
    [JsonPropertyName("customParameter")]
    public string? CustomParameter { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant to create an authorization URI or lookup an email identifier for.
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}