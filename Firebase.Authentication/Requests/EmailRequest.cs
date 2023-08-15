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
    /// <returns>A new Base.SendOobCodeRequest</returns>
    public static SendOobCodeRequest Verify() =>
        new(requestType: OobType.VerifyEmail);

    /// <summary>
    /// Send a new change email address email to the current users account
    /// </summary>
    /// <param name="newEmail">The new email the user is changing to</param>
    /// <returns>A new Base.SendOobCodeRequest</returns>
    public static SendOobCodeRequest Change(
        string newEmail) =>
        new(requestType: OobType.VerifyAndChangeEmail,
            newEmail: newEmail);

    /// <summary>
    /// Send a new reset password email to the given account
    /// </summary>
    /// <param name="email">The email the user is changing to</param>
    /// <returns>A new Base.SendOobCodeRequest</returns>
    public static SendOobCodeRequest ResetPassword(
        string email) =>
        new(requestType: OobType.ResetPassword,
            email: email);

    /// <summary>
    /// Send a new sign in with link email to the given account
    /// </summary>
    /// <param name="email">The email the user is changing to</param>
    /// <returns>A new Base.SendOobCodeRequest</returns>
    public static SendOobCodeRequest SignIn(
        string email,
        string continueUrl) =>
        new(requestType: OobType.SignInEmail,
            email: email,
            continueUrl: continueUrl);
}