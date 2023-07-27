using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.Base;

/// <summary>
/// Model to send a accounts.delete request
/// </summary>
public class DeleteRequest
{
    /// <summary>
    /// Creates a new DeleteRequest
    /// </summary>
    /// <param name="idToken">The Identity Platform ID token of the account to delete</param>
    /// <param name="localId">The ID of user account to delete</param>
    /// <param name="tenantId">The ID of the tenant that the account belongs to</param>
    /// <param name="targetProjectId">The ID of the project which the account belongs to</param>
    public DeleteRequest(
        string idToken,
        string? localId = null,
        string? tenantId = null,
        string? targetProjectId = null)
    {
        IdToken = idToken;
        LocalId = localId;
        TenantId = tenantId;
        TargetProjectId = targetProjectId;
    }

    /// <summary>
    /// The Identity Platform ID token of the account to delete
    /// </summary>
    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }

    /// <summary>
    /// The ID of user account to delete
    /// </summary>
    [JsonPropertyName("localId")]
    public string? LocalId { get; set; }

    /// <summary>
    /// The ID of the tenant that the account belongs to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    /// <summary>
    /// The ID of the project which the account belongs to
    /// </summary>
    [JsonPropertyName("targetProjectId")]
    public string? TargetProjectId { get; set; }
}