using Firebase.Authentication.Requests.IdentityPlatform;

namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new link to user for different authenticaion methods
/// </summary>
public abstract class LinkRequest
{
    /// <summary>
    /// Link user to an email and password
    /// </summary>
    /// <param name="email">The email the user is linking to</param>
    /// <param name="password">The password for the use</param>
    /// <returns>A new UpdateRequest</returns>
    public static LinkToPasswordRequest ToEmailPassword(
        string email,
        string password) =>
        new(idToken: default!,
            email: email,
            password: password);


    /// <summary>
    /// Link user to a phone number
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information from the response of sendVerificationCode</param>
    /// <param name="code">User-entered verification code from an SMS sent to the user's phone</param>
    /// <returns>A new SignInWithPhoneNumberRequest</returns>
    public static LinkToPhoneNumberRequest ToPhoneNumber(
        string sessionInfo,
        string code) =>
        new(idToken: default!,
            sessionInfo: sessionInfo,
            code: code);


    /// <summary>
    /// Link user to a email via link
    /// </summary>
    /// <param name="email">The email address the link-user link was sent to</param>
    /// <param name="code">The out-of-band code from the email link</param>
    /// <returns>A new SignInWithEmailLinkRequest</returns>
    public static LinkToEmailLinkRequest ToEmailLink(
        string email,
        string code) =>
        new(oobCode: code,
            email: email,
            idToken: default!);


    /// <summary>
    /// Link to a provider redirected url
    /// </summary>
    /// <param name="redirectedUri">The url to which the provider redirected the user back to</param>
    /// <param name="sessionId">The respective session id from a previous call</param>
    /// <returns>A new SignInWithIdpRequest</returns>
    public static LinkToIdpRequest ToProviderRedirect(
        string redirectedUri,
        string sessionId) =>
        new(requestUri: redirectedUri,
            sessionId: sessionId,
            idToken: default!);
}