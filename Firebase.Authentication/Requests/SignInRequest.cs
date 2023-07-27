using Firebase.Authentication.Requests.Base;

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
        new(email, password);

    /// <summary>
    /// Sign in with a custom token
    /// </summary>
    /// <param name="token">A Firebase Auth custom token from which to create an ID and refresh token pair</param>
    /// <returns>A new SignInWithCustomTokenRequest</returns>
    public static SignInWithCustomTokenRequest WithCustomToken(
        string token) =>
        new(token);
}