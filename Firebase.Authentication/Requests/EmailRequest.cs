using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new email for different purposes
/// </summary>
public abstract class EmailRequest
{
    /// <summary>
    /// Send a verify email to the current users account
    /// </summary>
    /// <returns>A new email verify email request</returns>
    public static EmailRequest Verify() =>
        new SendOobCodeRequest(
            requestType: OobType.VerifyEmail);

    /// <summary>
    /// Send a new change email address email to the current users account
    /// </summary>
    /// <param name="newEmail">The new email the user is changing to</param>
    /// <returns>A new email change email request</returns>
    public static EmailRequest Change(
        string newEmail) =>
        new SendOobCodeRequest(
            requestType: OobType.VerifyAndChangeEmail,
            newEmail: newEmail);

    /// <summary>
    /// Send a new reset password email to the given account
    /// </summary>
    /// <param name="email">The email the user is changing to</param>
    /// <returns>A new reset password email request</returns>
    public static EmailRequest ResetPassword(
        string email) =>
        new SendOobCodeRequest(
            requestType: OobType.ResetPassword,
            email: email);

    /// <summary>
    /// Send a new sign in with link email to the given account
    /// </summary>
    /// <param name="email">The email the user is changing to</param>
    /// <returns>A new email sign in email request</returns>
    public static EmailRequest SignIn(
        string email,
        string continueUrl) =>
        new SendOobCodeRequest(
            requestType: OobType.SignInEmail,
            email: email,
            continueUrl: continueUrl);
}