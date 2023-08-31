using Firebase.Authentication.Types;

namespace Firebase.Authentication.Models;

/// <summary>
/// Represents the sign in methods of a specific user
/// </summary>
public class SignInMethod
{
    /// <summary>
    /// Creates a new SignInMethod
    /// </summary>
    /// <param name="email">The email of the users account</param>
    /// <param name="providers">The list of sign-in methods that the user has previously used</param>
    /// <param name="isRegistered">Whether the email identifier represents an existing account</param>
    public SignInMethod(
        string email,
        Provider[]? providers,
        bool isRegistered)
    {
        Email = email;
        Providers = providers;
        IsRegistered = isRegistered;
    }

    /// <summary>
    /// The email of the users account
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// The list of sign-in methods that the user has previously used
    /// </summary>
    public Provider[]? Providers { get; }

    /// <summary>
    /// Whether the email identifier represents an existing account
    /// </summary>
    public bool IsRegistered { get; }
}