using System.Runtime.Serialization;

namespace Firebase.Authentication.Types;

/// <summary>
/// The OOB request type
/// </summary>
public enum OobType
{
    /// <summary>
    /// Oob code type is not specified
    /// </summary>
    [EnumMember(Value = "OOB_REQ_TYPE_UNSPECIFIED")]
    Unspecified,

    /// <summary>
    /// Reset password
    /// </summary>
    [EnumMember(Value = "PASSWORD_RESET")]
    ResetPassword,

    /// <summary>
    /// Verify the account's email address by sending an email
    /// </summary>
    [EnumMember(Value = "VERIFY_EMAIL")]
    VerifyEmail,

    /// <summary>
    /// Sign in with email only
    /// </summary>
    [EnumMember(Value = "EMAIL_SIGNIN")]
    SignInEmail,

    /// <summary>
    /// This flow sends an email to the specified new email, and when applied by clicking the link in the email changes the account's email to the new email
    /// </summary>
    [EnumMember(Value = "VERIFY_AND_CHANGE_EMAIL")]
    VerifyAndChangeEmail,
}