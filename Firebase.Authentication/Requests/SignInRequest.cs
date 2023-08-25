using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests.IdentityPlatform;

namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new sign in request for different Authentication methods
/// </summary>
public abstract class SignInRequest
{
    /// <summary>
    /// Sign in with an email and password
    /// </summary>
    /// <param name="email">The email the user is signing in with</param>
    /// <param name="password">The password for the user</param>
    /// <returns>A new sign in with email and password request</returns>
    public static SignInRequest WithEmailPassword(
        string email,
        string password) =>
        new SignInWithPasswordRequest(
            email: email,
            password: password);


    /// <summary>
    /// Sign in with a custom token
    /// </summary>
    /// <param name="token">A Firebase Auth custom token from which to create an ID and refresh token pair</param>
    /// <returns>A new sign in with custom token request</returns>
    public static SignInRequest WithCustomToken(
        string token) =>
        new SignInWithCustomTokenRequest(
            token: token);


    /// <summary>
    /// Sign in with a phone number
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information from the response of sendVerificationCode</param>
    /// <param name="code">User-entered verification code from an SMS sent to the user's phone</param>
    /// <returns>A new sign in with phone number request</returns>
    public static SignInRequest WithPhoneNumber(
        string sessionInfo,
        string code) =>
        new SignInWithPhoneNumberRequest(
            sessionInfo: sessionInfo,
            code: code);


    /// <summary>
    /// Sign in with a email via link
    /// </summary>
    /// <param name="email">The email address the sign-in link was sent to</param>
    /// <param name="code">The out-of-band code from the email link</param>
    /// <returns>A new sign in with email link request</returns>
    public static SignInRequest WithEmailLink(
        string email,
        string code) =>
        new SignInWithEmailLinkRequest(
            oobCode: code,
            email: email);


    /// <summary>
    /// Sign in with a provider redirected url
    /// </summary>
    /// <param name="redirectedUri">The url to which the provider redirected the user back to</param>
    /// <param name="sessionId">The respective session id from a previous call</param>
    /// <returns>A new sign in with provider redirect request</returns>
    public static SignInRequest WithProviderRedirect(
        string redirectedUri,
        string sessionId) =>
        new SignInWithIdpRequest(
            requestUri: redirectedUri,
            sessionId: sessionId);

    /// <summary>
    /// Sign in with a provider flow
    /// </summary>
    /// <param name="flow">The provider flow used to sign in</param>
    /// <returns></returns>
    public static SignInRequest WithProviderFlow(
        IProviderFlow flow) =>
        new SignInWithProviderFlowRequest(
            flow: flow);
}