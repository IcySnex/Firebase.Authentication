using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Requests.IdentityPlatform;

namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new link to user for different Authentication methods
/// </summary>
public abstract class LinkRequest
{
    /// <summary>
    /// Link user to an email and password
    /// </summary>
    /// <param name="email">The email the user is linking to</param>
    /// <param name="password">The password for the use</param>
    /// <returns>A new link to email and password request</returns>
    public static LinkRequest ToEmailPassword(
        string email,
        string password) =>
        new LinkToPasswordRequest(
            idToken: default!,
            email: email,
            password: password);


    /// <summary>
    /// Link user to a phone number
    /// </summary>
    /// <param name="sessionInfo">Encrypted session information from the response of sendVerificationCode</param>
    /// <param name="code">User-entered verification code from an SMS sent to the user's phone</param>
    /// <returns>A new link to phone number request</returns>
    public static LinkRequest ToPhoneNumber(
        string sessionInfo,
        string code) =>
        new LinkToPhoneNumberRequest(
            idToken: default!,
            sessionInfo: sessionInfo,
            code: code);


    /// <summary>
    /// Link user to a email via link
    /// </summary>
    /// <param name="email">The email address the link-user link was sent to</param>
    /// <param name="code">The out-of-band code from the email link</param>
    /// <returns>A new link to email link request</returns>
    public static LinkRequest ToEmailLink(
        string email,
        string code) =>
        new LinkToEmailLinkRequest(
            oobCode: code,
            email: email,
            idToken: default!);


    /// <summary>
    /// Link to a provider redirected url
    /// </summary>
    /// <param name="redirectedUri">The url to which the provider redirected the user back to</param>
    /// <param name="sessionId">The respective session id from a previous call</param>
    /// <returns>A new link to provider redirect request</returns>
    public static LinkRequest ToProviderRedirect(
        string redirectedUri,
        string sessionId) =>
        new LinkToIdpRequest(
            requestUri: redirectedUri,
            sessionId: sessionId,
            idToken: default!);

    /// <summary>
    /// Link to a provider flow
    /// </summary>
    /// <param name="flow">The provider flow used to link to</param>
    /// <returns></returns>
    public static LinkRequest ToProviderFlow(
        IProviderFlow flow) =>
        new LinkToProviderFlowRequest(
            flow: flow);
}