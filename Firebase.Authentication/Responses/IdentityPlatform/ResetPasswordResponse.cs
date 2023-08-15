using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Models;
using Firebase.Authentication.Types;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.IdentityPlatform;

/// <summary>
/// Model to recieve a accounts.resetPassword response 
/// </summary>
public class ResetPasswordResponse
{
    /// <summary>
    /// Creates a new ResetPasswordResponse
    /// </summary>
    /// <param name="email">The email associated with the out-of-band code that was used</param>
    /// <param name="newEmail">The new email</param>
    /// <param name="requestType">The OOB request type</param>
    /// <param name="mfaInfo">The multi-factor authentication (MFA) providers information</param>
    [JsonConstructor]
    public ResetPasswordResponse(
        string email,
        string? newEmail,
        OobType? requestType,
        MfaEnrollment? mfaInfo)
    {
        Email = email;
        NewEmail = newEmail;
        RequestType = requestType;
        MfaInfo = mfaInfo;
    }

    /// <summary>
    /// The email associated with the out-of-band code that was used
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; }

    /// <summary>
    /// The new email
    /// </summary>
    [JsonPropertyName("newEmail")]
    public string? NewEmail { get; }

    /// <summary>
    /// The OOB request type
    /// </summary>
    [JsonConverter(typeof(OobTypeJsonConverter))]
    [JsonPropertyName("requestType")]
    public OobType? RequestType { get; }

    /// <summary>
    /// The multi-factor authentication (MFA) providers information
    /// </summary>
    [JsonPropertyName("mfaInfo")]
    public MfaEnrollment? MfaInfo { get; }
}