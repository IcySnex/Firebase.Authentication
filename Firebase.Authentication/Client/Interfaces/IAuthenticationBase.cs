using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Client.Interfaces;

/// <summary>
/// Base client for all low level identity platform accounts actions
/// <br/>
/// REST documentation: <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts"/>
/// </summary>
public interface IAuthenticationBase
{
    /// <summary>
    /// If an email identifier is specified, checks and returns if any user account is registered with the email. If there is a registered account, fetches all providers associated with the account's email.
    /// <br/>
    /// If the provider ID of an Identity Provider(IdP) is specified, creates an authorization URI for the IdP. The user can be directed to this URI to sign in with the IdP.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/createAuthUri"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.createAuthUri response</returns>
    Task<CreateAuthUrlResponse> CreateAuthUriAsync(
        CreateAuthUriRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user's account
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/delete"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.delete response</returns>
    Task DeleteAsync(
        DeleteRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets account information for all matched accounts. For an end user request, retrieves the account of the end user. For an admin request with Google OAuth 2.0 credential, retrieves one or multiple account(s) with matching criteria.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/lookup"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.lookup response</returns>
    Task<LookupResponse> LookupAsync(
        LookupRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets the password of an account either using an out-of-band code generated by SendOobCodeAsync or by specifying the email and password of the account to be modified. Can also check the purpose of an out-of-band code without consuming it.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/resetPassword"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.resetPassword response</returns>
    Task<ResetPasswordResponse> ResetPasswordASync(
        ResetPasswordRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an out-of-band confirmation code for an account. Requests from a authenticated request can optionally return a link including the OOB code instead of sending it.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/sendOobCode"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.sendOobCode response</returns>
    Task<SendOobCodeResponse> SendOobCodeAsync(
        SendOobCodeRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a SMS verification code for phone number sign-in.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/sendVerificationCode"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.sendVerificationCode response</returns>
    Task<SendVerificationCodeResponse> SendVerificationCodeAsync(
        SendVerificationCodeRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs in or signs up a user by exchanging a custom Auth token. Upon a successful sign-in or sign-up, a new Identity Platform ID token and refresh token are issued for the user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signInWithCustomToken"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signInWithCustomToken response</returns>
    Task<SignInWithCustomTokenResponse> SignInWithCustomTokenAsync(
        SignInWithCustomTokenRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs in or signs up a user with a out-of-band code from an email link. If a user does not exist with the given email address, a user record will be created. If the sign-in succeeds, an Identity Platform ID and refresh token are issued for the authenticated user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signInWithEmailLink"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signInWithEmailLink response</returns>
    Task<SignInWithEmailLinkResponse> SignInWithEmailLinkAsync(
        SignInWithEmailLinkRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs in or signs up a user using credentials from an Identity Provider (IdP). This is done by manually providing an IdP credential, or by providing the authorization response obtained via the authorization request from accounts.createAuthUri. If the sign-in succeeds, a new Identity Platform ID token and refresh token are issued for the authenticated user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signInWithIdp"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signInWithIdp response</returns>
    Task<SignInWithIdpResponse> SignInWithIdpAsync(
        SignInWithIdpRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs in a user with email and password. If the sign-in succeeds, a new Identity Platform ID token and refresh token are issued for the authenticated user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signInWithPassword"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signInWithPassword response</returns>
    Task<SignInWithPasswordResponse> SignInWithPasswordAsync(
        SignInWithPasswordRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes a phone number authentication attempt. If a user already exists with the given phone number, an ID token is minted for that user. Otherwise, a new user is created and associated with the phone number. This method may also be used to link a phone number to an existing user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signInWithPhoneNumber"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signInWithPhoneNumber response</returns>
    Task<SignInWithPhoneNumberResponse> SignInWithPhoneNumberAsync(
        SignInWithPhoneNumberRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Signs up a new email and password user or anonymous user, or upgrades an anonymous user to email and password. For an admin request with a Google OAuth 2.0 credential with the proper permissions, creates a new anonymous, email and password, or phone number user.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/signUp"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.signUp response</returns>
    Task<SignUpResponse> SignUpAsync(
        SignUpRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates account-related information for the specified user by setting specific fields or applying action codes. Requests from administrators and end users are supported.
    /// <para/>
    /// <see href="https://cloud.google.com/identity-platform/docs/reference/rest/v1/accounts/update"/>
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <param name="locale">The language (Two Letter ISO code) in which all emails will be send to the user</param>
    /// <param name="cancellationToken">The token to cancel this actioun</param>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    /// <returns>A new accounts.update response</returns>
    Task<UpdateResponse> UpdateAsync(
        UpdateRequest request,
        string? locale = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Exchange a refresh token for an ID token
    /// <para/>
    /// <see href="https://firebase.google.com/docs/reference/rest/auth#section-refresh-token"/>
    /// </summary>
    /// <returns>A new securetoken.token response response</returns>
    /// <exception cref="Firebase.Authentication.Exceptions.AuthenticationException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.FormatException">May occurs when adding a header fails</exception>
    /// <exception cref="System.ArgumentNullException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the post request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">May occurs when sending the post request fails</exception>
    Task<SecureTokenResponse> SecureTokenAsync(
        SecureTokenRequest request,
        CancellationToken cancellationToken = default);
}