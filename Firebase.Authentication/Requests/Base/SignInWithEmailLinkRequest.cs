using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.Base;

/// <summary>
/// Model to send a accounts.signInWithEmailLink request
/// </summary>
public class SignInWithEmailLinkRequest
{
    /// <summary>
    /// Creates a new SignInWithEmailLinkRequest
    /// </summary>
    /// <param name="oobCode">The out-of-band code from the email link</param>
    /// <param name="email">The email address the sign-in link was sent to</param>
    /// <param name="idToken">A valid ID token for an Identity Platform account</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    public SignInWithEmailLinkRequest(
        string oobCode,
        string email,
        string? idToken = null,
        string? tenantId = null)
    {
        OobCode = oobCode;
        Email = email;
        IdToken = idToken;
        TenantId = tenantId;
    }

    /// <summary>
    /// The out-of-band code from the email link
    /// </summary>
    [JsonPropertyName("oobCode")]
    public string OobCode { get; set; }

    /// <summary>
    /// The email address the sign-in link was sent to
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// A valid ID token for an Identity Platform account
    /// </summary>
    [JsonPropertyName("idToken")]
    public string? IdToken { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}