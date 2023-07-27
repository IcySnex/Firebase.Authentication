using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.Base;

/// <summary>
/// Model to send a accounts.lookup request
/// </summary>
public class LookupRequest
{
    /// <summary>
    /// Creates a new LookupRequest
    /// </summary>
    /// <param name="idToken">The Identity Platform ID token of the account to fetch</param>
    /// <param name="localIds">The ID of one or more accounts to fetch</param>
    /// <param name="emails">The email address of one or more accounts to fetch</param>
    /// <param name="phoneNumbers">The phone number of one or more accounts to fetch</param>
    /// <param name="federatedUserIds">The federated user identifier of one or more accounts to fetch</param>
    /// <param name="tenantId">The ID of the tenant that the account belongs to</param>
    /// <param name="targetProjectId">The ID of the Google Cloud project that the account or the Identity Platform tenant specified by tenantId belongs to</param>
    public LookupRequest(
        string idToken,
        string[]? localIds = null,
        string[]? emails = null,
        string[]? phoneNumbers = null,
        FederatedUserIdentifier[]? federatedUserIds = null,
        string? tenantId = null,
        string? targetProjectId = null)
    {
        IdToken = idToken;
        LocalIds = localIds;
        Emails = emails;
        PhoneNumbers = phoneNumbers;
        FederatedUserIds = federatedUserIds;
        TenantId = tenantId;
        TargetProjectId = targetProjectId;
    }

    /// <summary>
    /// The Identity Platform ID token of the account to fetch
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// The ID of one or more accounts to fetch
    /// </summary>
    [JsonPropertyName("localId")]
    public string[]? LocalIds { get; set; }

    /// <summary>
    /// The provider of the IdP for the user to sign in with
    /// </summary>
    [JsonPropertyName("email")]
    public string[]? Emails { get; set; }

    /// <summary>
    /// The phone number of one or more accounts to fetch
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string[]? PhoneNumbers { get; set; }

    /// <summary>
    /// An opaque string used to maintain contextual information between the authentication request and the callback from the IdP
    /// </summary>
    [JsonPropertyName("federatedUserId")]
    public FederatedUserIdentifier[]? FederatedUserIds { get; set; }

    /// <summary>
    /// The ID of the tenant that the account belongs to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// The ID of the Google Cloud project that the account or the Identity Platform tenant specified by tenantId belongs to
    /// </summary>
    [JsonPropertyName("targetProjectId")]
    public string? TargetProjectId { get; set; }
}