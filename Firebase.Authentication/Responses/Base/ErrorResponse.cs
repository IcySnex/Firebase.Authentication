using System.Net;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve an error response
/// </summary>
internal class ErrorResponse
{
    /// <summary>
    /// Creates a new ErrorResponse
    /// (Should only be used by AuthenticationError.FromResponseData())
    /// </summary>
    /// <param name="error">The inner error to create the ErrorResponse</param>
    [JsonConstructor]
    public ErrorResponse(
        ErrorResponseError error)
    {
        Error = error;
    }


    /// <summary>
    /// The inner error to create the ErrorResponse
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorResponseError Error { get; }
}


/// <summary>
/// Model to recieve the inner error response
/// </summary>
internal class ErrorResponseError
{
    /// <summary>
    /// Creates a new ErrorResponseError
    /// (Should only be used by AuthenticationError.FromResponseData())
    /// </summary>
    /// <param name="code">The returned HTTP status code</param>
    /// <param name="message">The error message</param>
    [JsonConstructor]
    public ErrorResponseError(
        HttpStatusCode code,
        string message)
    {
        Code = code;
        Message = message;
    }


    /// <summary>
    /// The returned HTTP status code
    /// </summary>
    [JsonPropertyName("code")]
    public HttpStatusCode Code { get; }

    /// <summary>
    /// The error message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; }
}