using Firebase.Authentication.Requests.IdentityPlatform;

namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new sign in request for different authenticaion methods
/// </summary>
public abstract class SignInRequest
{
    /// <summary>
    /// Sign in with an email and password
    /// </summary>
    /// <param name="email">The email the user is signing in with</param>
    /// <param name="password">The password for the account</param>
    /// <returns>A new SignInWithPasswordRequest</returns>
    public static SignInWithPasswordRequest WithEmailPassword(
        string email,
        string password) =>
        new(email: email,
            password: password);


    /// <summary>
    /// Sign in with a custom token
    /// </summary>
    /// <param name="token">A Firebase Auth custom token from which to create an ID and refresh token pair</param>
    /// <returns>A new SignInWithCustomTokenRequest</returns>
    public static SignInWithCustomTokenRequest WithCustomToken(
        string token) =>
        new(token: token);


    /// <summary>
    /// Sign in with a phone number
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information from the response of sendVerificationCode</param>
    /// <param name="code">User-entered verification code from an SMS sent to the user's phone</param>
    /// <returns>A new SignInWithPhoneNumberRequest</returns>
    public static SignInWithPhoneNumberRequest WithPhoneNumber(
        string sessionInfo,
        string code) =>
        new(sessionInfo: sessionInfo,
            code: code);


    /// <summary>
    /// Sign in with a phone number
    /// </summary>
    /// <param name="email">The email address the sign-in link was sent to</param>
    /// <param name="code">The out-of-band code from the email link</param>
    /// <returns>A new SignInWithPhoneNumberRequest</returns>
    public static SignInWithEmailLinkRequest WithEmailLink(
        string email,
        string code) =>
        new(oobCode: code,
            email: email);
}