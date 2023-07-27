using System.Text.Json.Serialization;

namespace Firebase.Authentication.Models;

/// <summary>
/// Model representing multi-factor authentication related information
/// </summary>
public class MfaInfo
{
    /// <summary>
    /// Creates a new MfaInfo
    /// </summary>
    /// <param name="enrollments">The second factors the user has enrolled</param>
    [JsonConstructor]
    public MfaInfo(
        MfaEnrollment[] enrollments)
    {
        Enrollments = enrollments;
    }

    /// <summary>
    /// The second factors the user has enrolled
    /// </summary>
    [JsonPropertyName("enrollments")]
    public MfaEnrollment[] Enrollments { get; }
}

/// <summary>
/// Model representing Information on which multi-factor authentication (MFA) providers are enabled for an account
/// </summary>
public class MfaEnrollment
{
    /// <summary>
    /// Creates a new MfaEnrollment
    /// </summary>
    /// <param name="mfaEnrollmentId">ID of this MFA option</param>
    /// <param name="displayName">Display name for this mfa option e.g. "corp cell phone"</param>
    /// <param name="enrolledAt">Timestamp when the account enrolled this second factor"</param>
    /// <param name="phoneInfo">Normally this will show the phone number associated with this enrollment"</param>
    /// <param name="unobfuscatedPhoneInfo">Unobfuscated phoneInfo"</param>
    [JsonConstructor]
    public MfaEnrollment(
        string mfaEnrollmentId,
        string displayName,
        DateTime enrolledAt,
        string phoneInfo,
        string? unobfuscatedPhoneInfo = null)
    {
        MfaEnrollmentId = mfaEnrollmentId;
        DisplayName = displayName;
        EnrolledAt = enrolledAt;
        PhoneInfo = phoneInfo;
        UnobfuscatedPhoneInfo = unobfuscatedPhoneInfo;
    }

    /// <summary>
    /// The second factors the user has enrolled
    /// </summary>
    [JsonPropertyName("mfaEnrollmentId")]
    public string MfaEnrollmentId { get; }

    /// <summary>
    /// Display name for this mfa option e.g. "corp cell phone"
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// Timestamp when the account enrolled this second factor
    /// </summary>
    [JsonPropertyName("enrolledAt")]
    public DateTime EnrolledAt { get; }

    /// <summary>
    /// Normally this will show the phone number associated with this enrollment
    /// </summary>
    [JsonPropertyName("phoneInfo")]
    public string PhoneInfo { get; }

    /// <summary>
    /// Unobfuscated phoneInfo
    /// </summary>
    [JsonPropertyName("unobfuscatedPhoneInfo")]
    public string? UnobfuscatedPhoneInfo { get; }
}

/// <summary>
/// Model representing a multi-factor authentication (MFA) factor
/// </summary>
public class MfaFactor
{
    /// <summary>
    /// Creates a new MfaFactor
    /// </summary>
    /// <param name="displayName">Display name for this mfa option e.g. "corp cell phone"</param>
    /// <param name="phoneInfo">Phone number to receive OTP for MFA"</param>
    [JsonConstructor]
    public MfaFactor(
        string displayName,
        string phoneInfo)
    {
        DisplayName = displayName;
        PhoneInfo = phoneInfo;
    }

    /// <summary>
    /// Display name for this mfa option e.g. "corp cell phone"
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; }

    /// <summary>
    /// Phone number to receive OTP for MFA
    /// </summary>
    [JsonPropertyName("phoneInfo")]
    public string PhoneInfo { get; }
}