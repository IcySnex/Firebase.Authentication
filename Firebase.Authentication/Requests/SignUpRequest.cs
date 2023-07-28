namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new sign up request for different authenticaion methods
/// </summary>
public abstract class SignUpRequest
{
    /// <summary>
    /// Sign up with an email and password
    /// </summary>
    /// <param name="email">The email the user is signing up with</param>
    /// <param name="password">The password for the account</param>
    /// <param name="displayName">The display name for the account</param>
    /// <param name="photoUrl">The photo url for the account</param>
    /// <returns>A new Base.SignUpRequest</returns>
    public static Base.SignUpRequest WithEmailPassword(
        string email,
        string password,
        string? displayName = null,
        string? photoUrl = null) =>
        new(email: email,
            password:
            password, 
            displayName: displayName,
            photoUrl: photoUrl);

    /// <summary>
    /// Sign up anonymously
    /// </summary>
    /// <param name="displayName">The display name for the account</param>
    /// <param name="photoUrl">The photo url for the account</param>
    /// <returns>A new Base.SignUpRequest</returns>
    public static Base.SignUpRequest Anonymously(
        string? displayName = null,
        string? photoUrl = null) =>
        new(displayName: displayName,
            photoUrl: photoUrl);
}