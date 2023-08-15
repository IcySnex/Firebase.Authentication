using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.sendVerificationCode request
/// </summary>
public class SendVerificationCodeRequest
{
    /// <summary>
    /// Creates a new SendVerificationCodeRequest
    /// </summary>
    /// <param name="phoneNumber">The phone number to send the verification code to in E.164 format</param>
    /// <param name="recaptchaToken">Recaptcha token for app verification. To easily get an official Google reCAPTCHA token on WPF, WinUI, UWP, WinForms or console you can use <see href="https://icysnex.github.io/ReCaptcha.Desktop/"/></param>
    /// <param name="tenantId">Tenant ID of the Identity Platform tenant the user is signing in to</param>
    public SendVerificationCodeRequest(
        string phoneNumber,
        string recaptchaToken,
        string? tenantId = null)
    {
        PhoneNumber = phoneNumber;
        RecaptchaToken = recaptchaToken;
        TenantId = tenantId;
    }

    /// <summary>
    /// The phone number to send the verification code to in E.164 format
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Recaptcha token for app verification
    /// <para/>
    /// To easily get an official Google reCAPTCHA token on WPF, WinUI, UWP, WinForms or console you can use <see href="https://icysnex.github.io/ReCaptcha.Desktop/"/>
    /// </summary>
    [JsonPropertyName("recaptchaToken")]
    public string RecaptchaToken { get; set; }

    /// <summary>
    /// Tenant ID of the Identity Platform tenant the user is signing in to
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}