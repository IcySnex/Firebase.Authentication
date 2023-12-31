﻿using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using System.ComponentModel;

namespace Firebase.Authentication.Client.Interfaces;

/// <summary>
/// Client for all high level Firebase Authentication actions
/// </summary>
public interface IAuthenticationClient : INotifyPropertyChanged
{

    /// <summary>
    /// The current users authenitcaion credential
    /// </summary>
    public Credential? CurrentCredential { get; }

    /// <summary>
    /// Checks if the current credential is expired and if so sends a refresh request 
    /// </summary>
    /// <param name="forceRefresh">When true the expiration period of the current credential is ignored it always returns a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <returns>An always valid Authentication credential</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task<Credential> GetFreshCredentialAsync(
        bool forceRefresh = false,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// The user who is currently signed into the client 
    /// </summary>
    public UserInfo? CurrentUser { get; }

    /// <summary>
    /// Checks if the current user is valid based on the given period and if not sends a user data request 
    /// </summary>
    /// <param name="validityPeriod">The time span at which the user should be refreshed to maintain up-to-date information. Null if a single time user info is wanted</param>
    /// <param name="forceRefresh">When true the validity period of the current user info is ignored it always returns a fresh user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <returns>An always uo to date user info</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task<UserInfo> GetFreshUserAsync(
        TimeSpan? validityPeriod = null,
        bool forceRefresh = false,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// Signs up an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign up request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task SignUpAsync(
        SignUpRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs in an user with the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The sign in request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task SignInAsync(
        SignInRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs out the current user by deleting the current credential and user info
    /// </summary>
    public void SignOut();


    /// <summary>
    /// Links the current user to the given method and refreshes the current user
    /// </summary>
    /// <param name="request">The link user request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task LinkAsync(
        LinkRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Uninks the current user from the given method and refreshes the current user
    /// </summary>
    /// <param name="provider">The provider from which the user is unlinking</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task UnlinkAsync(
        Provider provider,
        CancellationToken cancellationToken = default);
    /// <summary>
    /// Uninks the current user from the given method and refreshes the current user
    /// </summary>
    /// <param name="providers">The providers from which the user is unlinking</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task UnlinkAsync(
        Provider[] providers,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task DeleteAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the current users account
    /// </summary>
    /// <param name="displayName">The new display name</param>
    /// <param name="photoUrl">The new photo url</param>
    /// <param name="deleteDisplayName">Wether the display name of the user should be deleted</param>
    /// <param name="deletePhotoUrl">Wether the display name of the user should be deleted</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task UpdateAsync(
        string? displayName,
        string? photoUrl,
        bool deleteDisplayName = false,
        bool deletePhotoUrl = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the current users email address
    /// </summary>
    /// <param name="email">The new email address (null if email should be removed)</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task ChangeEmailAsync(
        string? email,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the current users password
    /// </summary>
    /// <param name="newPassword">The new password</param>
    /// <param name="oldPassword">The old password to verify the users identity</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.UserNotFoundException">Occurrs if the user was not found</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">Occurrs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public Task ChangePasswordAsync(
        string newPassword,
        string oldPassword,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a new verify email to the current users account
    /// </summary>
    /// <param name="request">The email request</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.MissingCredentialException">May occurs when the current credential is null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The email address the email got sent to</returns>
    public Task<string> SendEmailAsync(
        EmailRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// Deletes the current users account
    /// </summary>
    /// <param name="newPassword">The new password to be set for this account</param>
    /// <param name="code">An out-of-band (OOB) code generated by an prior request</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The email associated with the password reset</returns>
    public Task<string> ResetPasswordAsync(
        string newPassword,
        string code,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks and returns if any user account is registered with the email. If there is a registered account, fetches all providers associated with the accounts email
    /// </summary>
    /// <param name="email">The email of the users account to fetch associated providers for</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>A list of sign in methods for the users account. Null if email is not registered</returns>
    public Task<SignInMethod> GetSignInMethodAsync(
        string email,
        string continueUri = "http://localhost",
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a SMS verification code for phone number sign-in.
    /// </summary>
    /// <param name="phoneNumber">The phone number to send the verification code to in E.164 format</param>
    /// <param name="recaptchaToken">Recaptcha token for app verification.<br/> To easily get an official Google reCAPTCHA token on WPF, WinUI, UWP, WinForms or console you can use <see href="https://icysnex.github.io/ReCaptcha.Desktop/"/>.<br/> You can use <see cref="IAuthenticationBase.GetRecaptchaParamsAsync(CancellationToken)"/> to get a reCAPTCHA site key for your current project</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The Encrypted session information which can be used to sign in with the phone number</returns>
    public Task<string> SendVerificationCodeAsync(
        string phoneNumber,
        string recaptchaToken,
        string? locale = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an authorization URI for the given provider, to which the user can be redirected to for signing in
    /// </summary>
    /// <param name="provider">The email of the users account to fetch associated providers for</param>
    /// <param name="continueUri">The url the user will be redirected back</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>An authorization URI for the requested provider with the respective session id</returns>
    public Task<ProviderRedirect> CreateProviderRedirectAsync(
        Provider provider,
        string continueUri = "http://localhost",
        CancellationToken cancellationToken = default);


    /// <summary>
    /// Gets the reCAPTCHA v2 site key for the current project
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>A reCAPTCHA v2 site key</returns>
    public Task<string> GetRecaptchaSiteKeyAsync(
        CancellationToken cancellationToken = default);
}