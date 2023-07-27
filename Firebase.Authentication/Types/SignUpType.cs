namespace Firebase.Authentication.Types;

/// <summary>
/// The type of a SignUp request
/// </summary>
public enum SignUpType
{
    /// <summary>
    /// <see cref="SignUpEmailPasswordRequest"/>
    /// </summary>
    EmailPassword,

    /// <summary>
    /// <see cref="SignUpAnonymouslyRequest"/>
    /// </summary>
    Anonymously
}