using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a accounts.sendVerificationCode response 
/// </summary>
public class SendVerificationCodeResponse
{
    /// <summary>
    /// Creates a new SendVerificationCodeResponse
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information. This can be used in signInWithPhoneNumber to authenticate the phone number</param>
    [JsonConstructor]
    public SendVerificationCodeResponse(
        string sessionInfo)
    {
        SessionInfo = sessionInfo;
    }

    /// <summary>
    /// Encrypted session information
    /// <br/>
    /// This can be used in signInWithPhoneNumber to authenticate the phone number
    /// </summary>
    [JsonPropertyName("sessionInfo")]
    public string SessionInfo { get; }
}