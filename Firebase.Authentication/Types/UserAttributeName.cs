using System.Runtime.Serialization;

namespace Firebase.Authentication.Types;

/// <summary>
/// The account's attributes that can be deleted
/// </summary>
public enum UserAttributeName
{
    /// <summary>
    /// User attribute name is not specified
    /// </summary>
    [EnumMember(Value = "USER_ATTRIBUTE_NAME_UNSPECIFIED")]
    Unspecified,

    /// <summary>
    /// User attribute key name is email
    /// </summary>
    [EnumMember(Value = "EMAIL")]
    Email,

    /// <summary>
    /// User attribute key name is displayName
    /// </summary>
    [EnumMember(Value = "DISPLAY_NAME")]
    DisplayName,

    /// <summary>
    /// User attribute key name is provider
    /// </summary>
    [EnumMember(Value = "PROVIDER")]
    Provider,

    /// <summary>
    /// User attribute key name is photoURL
    /// </summary>
    [EnumMember(Value = "PHOTO_URL")]
    PhotoUrl,

    /// <summary>
    /// User attribute key name is password
    /// </summary>
    [EnumMember(Value = "PASSWORD")]
    Password,

    /// <summary>
    /// User attribute key name is rawUserInfo
    /// </summary>
    [EnumMember(Value = "RAW_USER_INFO")]
    RawUserInfo
}