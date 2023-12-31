﻿namespace Firebase.Authentication.Requests;

/// <summary>
/// Model to send a new sign up request for different Authentication methods
/// </summary>
public abstract class SignUpRequest
{
    /// <summary>
    /// Sign up with an email and password
    /// </summary>
    /// <param name="email">The email the user is signing up with</param>
    /// <param name="password">The password for the account</param>
    /// <param name="displayName">The display name for the account</param>
    /// <returns>A new sign up with email and password request</returns>
    public static SignUpRequest WithEmailPassword(
        string email,
        string password,
        string? displayName = null) =>
        new IdentityPlatform.SignUpRequest(
            email: email,
            password:
            password, 
            displayName: displayName);

    /// <summary>
    /// Sign up anonymously
    /// </summary>
    /// <returns>A new sign up anonymously request</returns>
    public static SignUpRequest Anonymously() =>
        new IdentityPlatform.SignUpRequest();
}