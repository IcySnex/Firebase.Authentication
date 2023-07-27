namespace Firebase.Authentication.Types;

/// <summary>
/// The type of a SignIn request
/// </summary>
public enum SignInType
{
    /// <summary>
    /// <see cref="VerifyCustomTokenRequest"/>
    /// </summary>
    CustomToken,

    /// <summary>
    /// <see cref="SignInEmailPasswordRequest"/>
    /// </summary>
    EmailPassword
}