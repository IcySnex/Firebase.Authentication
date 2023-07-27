using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.Base;

/// <summary>
/// Model to send a accounts.signInWithPassword request
/// </summary>
public class SignInWithPasswordRequest
{
    /// <summary>
    /// Creates a new SignInWithPasswordRequest
    /// </summary>
    /// <param name="email">The email the user is signing in with</param>
    /// <param name="password">The password for the account</param>
    /// <param name="returnSecureToken">Whether or not to return an ID and refresh token. Should always be true</param>
    /// <param name="captchaResponse">The reCAPTCHA token provided by the reCAPTCHA client-side integration</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant the user is signing in to</param>
    public SignInWithPasswordRequest(
        string email,
        string password,
        bool returnSecureToken = true,
        string? captchaResponse = null,
        string? tenantId = null)
    {
        Email = email;
        Password = password;
        ReturnSecureToken = returnSecureToken;
        CaptchaResponse = captchaResponse;
        TenantId = tenantId;
    }

    /// <summary>
    /// The email the user is signing in with
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The password for the account
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

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
}