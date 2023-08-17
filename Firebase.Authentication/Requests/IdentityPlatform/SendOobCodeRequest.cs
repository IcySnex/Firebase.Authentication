using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Requests.IdentityPlatform;

/// <summary>
/// Model to send a accounts.sendOobCode request
/// </summary>
public class SendOobCodeRequest : EmailRequest
{
    /// <summary>
    /// Creates a new SendOobCodeRequest
    /// </summary>
    /// <param name="requestType">The type of out-of-band (OOB) code to send. Depending on this value, other fields in this request will be required and/or have different meanings</param>
    /// <param name="email">The account's email address to send the OOB code to, and generally the email address of the account that needs to be updated</param>
    /// <param name="captchaResp">For a PASSWORD_RESET request, a reCaptcha response is required when the system detects possible abuse activity</param>
    /// <param name="userIp">The IP address of the caller. Required only for PASSWORD_RESET requests</param>
    /// <param name="newEmail">The email address the account is being updated to. Required only for VERIFY_AND_CHANGE_EMAIL requests</param>
    /// <param name="idToken">An ID token for the account. It is required for VERIFY_AND_CHANGE_EMAIL and VERIFY_EMAIL requests unless returnOobLink is set to true</param>
    /// <param name="continueUrl">The Url to continue after user clicks the link sent in email</param>
    /// <param name="targetProjectId">The Project ID of the Identity Platform project which the account belongs to</param>
    /// <param name="returnOobLink">Whether the confirmation link containing the OOB code should be returned in the response (no email is sent)</param>
    /// <param name="tenantId">The ID of the Identity Platform tenant to create an authorization URI or lookup an email identifier for</param>
    public SendOobCodeRequest(
        OobType requestType,
        string? email = null,
        string? captchaResp = null,
        string? userIp = null,
        string? newEmail = null,
        string? idToken = null,
        string? continueUrl = null,
        string? targetProjectId = null,
        bool? returnOobLink = null,
        string? tenantId = null)
    {
        RequestType = requestType;
        Email = email;
        CaptchaResp = captchaResp;
        UserIp = userIp;
        NewEmail = newEmail;
        IdToken = idToken;
        ContinueUrl = continueUrl;
        TargetProjectId = targetProjectId;
        ReturnOobLink = returnOobLink;
        TenantId = tenantId;
    }

    /// <summary>
    /// The type of out-of-band (OOB) code to send
    /// <br/>
    /// Depending on this value, other fields in this request will be required and/or have different meanings
    /// </summary>
    [JsonConverter(typeof(OobTypeJsonConverter))]
    [JsonPropertyName("requestType")]
    public OobType RequestType { get; set; }

    /// <summary>
    /// The account's email address to send the OOB code to, and generally the email address of the account that needs to be updated
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// For a PASSWORD_RESET request, a reCaptcha response is required when the system detects possible abuse activity
    /// </summary>
    [JsonPropertyName("captchaResp")]
    public string? CaptchaResp { get; set; }

    /// <summary>
    /// The IP address of the caller
    /// <br/>
    /// Required only for PASSWORD_RESET requests
    /// </summary>
    [JsonPropertyName("userIp")]
    public string? UserIp { get; set; }

    /// <summary>
    /// The email address the account is being updated to
    /// <br/>
    /// Required only for VERIFY_AND_CHANGE_EMAIL requests
    /// </summary>
    [JsonPropertyName("newEmail")]
    public string? NewEmail { get; set; }

    /// <summary>
    /// An ID token for the account
    /// <br/>
    /// It is required for VERIFY_AND_CHANGE_EMAIL and VERIFY_EMAIL requests unless returnOobLink is set to true
    /// </summary>
    [JsonPropertyName("idToken")]
    public string? IdToken { get; set; }

    /// <summary>
    /// The Url to continue after user clicks the link sent in email
    /// </summary>
    [JsonPropertyName("continueUrl")]
    public string? ContinueUrl { get; set; }

    /// <summary>
    /// The Project ID of the Identity Platform project which the account belongs to
    /// </summary>
    [JsonPropertyName("targetProjectId")]
    public string? TargetProjectId { get; set; }

    /// <summary>
    /// Whether the confirmation link containing the OOB code should be returned in the response (no email is sent)
    /// </summary>
    [JsonPropertyName("returnOobLink")]
    public bool? ReturnOobLink { get; set; }

    /// <summary>
    /// The ID of the Identity Platform tenant to create an authorization URI or lookup an email identifier for
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}