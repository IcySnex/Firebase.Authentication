using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.sendOobCode response 
/// </summary>
public class SendOobCodeResponse
{
    /// <summary>
    /// Creates a new SendOobCodeResponse
    /// </summary>
    /// <param name="oobCode">If returnOobLink is true in the request, the OOB code to send</param>
    /// <param name="email">If returnOobLink is false in the request, the email address the verification was sent to</param>
    /// <param name="oobLink">If returnOobLink is true in the request, the OOB link to be sent to the user</param>
    [JsonConstructor]
    public SendOobCodeResponse(
        string oobCode,
        string email,
        string oobLink)
    {
        OobCode = oobCode;
        Email = email;
        OobLink = oobLink;
    }

    /// <summary>
    /// If returnOobLink is true in the request, the OOB code to send
    /// </summary>
    [JsonPropertyName("oobCode")]
    public string? OobCode { get; }

    /// <summary>
    /// If returnOobLink is false in the request, the email address the verification was sent to
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; }

    /// <summary>
    /// If returnOobLink is true in the request, the OOB link to be sent to the user
    /// </summary>
    [JsonPropertyName("oobLink")]
    public string? OobLink { get; }
}