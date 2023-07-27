using System.Runtime.Serialization;

namespace Firebase.Authentication.Types;

/// <summary>
/// The Firebase token grand type
/// </summary>
public enum GrantType
{
    /// <summary>
    /// Should always be RefreshToken
    /// </summary>
    [EnumMember(Value = "refresh_token")]
    RefreshToken,
}