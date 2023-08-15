using Firebase.Authentication.Configuration;
using Firebase.Authentication.Exceptions;
using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Internal.HttpHandler;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Internal;

/// <summary>
/// Helper which handles all HTTP requests
/// </summary>
internal class RequestHelper
{
    readonly HttpClient httpClient;
    readonly ILogger? logger;

    /// <summary>
    /// Creates a new RequestHelper
    /// </summary>
    /// <param name="authenticationConfig">The configuration for the HttpClient</param>
    public RequestHelper(
        AuthenticationConfig config,
        ILogger? logger = null)
    {
        HttpMessageHandler innerHandler = config.HttpConfiguration.Proxy is null ? new HttpClientHandler() : new ProxyHttpClientHandler(config.HttpConfiguration.Proxy);
        ApiKeyHttpDelegatingHandler apiKeyHandler = new(config.ApiKey, innerHandler);
        httpClient = new(apiKeyHandler);

        if (config.HttpConfiguration.Timeout.HasValue)
            httpClient.Timeout = config.HttpConfiguration.Timeout.Value;

        this.logger = logger;
        logger?.LogInformation($"[RequestHelper-.ctor] RequestHelper has been initialized.");
    }


    /// <summary>
    /// Sends a new GET request to the given uri
    /// </summary>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The HTTP response message</returns>
    public Task<HttpResponseMessage> GetAsync(
        string uri,
        CancellationToken cancellationToken = default)
    {
        // Create HTTP request
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new(uri)
        };

        // Send HTTP request
        logger?.LogInformation($"[RequestHelper-GetAsync] Sending HTTP reuqest. GET: {uri}.");
        return httpClient.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Sends a new GET request to the given uri and validates it
    /// </summary>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The HTTP response message</returns>
    public async Task<string> GetAndValidateAsync(
        string uri,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        HttpResponseMessage httpResponse = await GetAsync(uri, cancellationToken)
            .ConfigureAwait(false);
        // Parse HTTP response data
        string httpResponseData = await httpResponse.Content.ReadAsStringAsync()
            .ConfigureAwait(false);

        // Check for exception
        if (!httpResponse.IsSuccessStatusCode)
        {
            logger?.LogError($"[RequestHelper-GetAndValidateAsync] HTTP request failed. Statuscode: {httpResponse.StatusCode}.");
            throw IdentityPlatformException.FromResponseData(httpResponseData);
        }

        // Return response data
        return httpResponseData;
    }

    /// <summary>
    /// Sends a new GET request to the given uri, validates it and parses it
    /// </summary>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The HTTP response message</returns>
    public async Task<T> GetAndParseAsync<T>(
        string uri,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        string httpResponseData = await GetAndValidateAsync(uri, cancellationToken)
            .ConfigureAwait(false);

        // Parse as Type T and return
        return JsonHelper.Deserialize<T>(httpResponseData);
    }


    /// <summary>
    /// Sends a new POST request to the given uri with the serializes body
    /// </summary>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="body">The body which should be serialized</param>
    /// <param name="headers">The optional headers for the request</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The HTTP response message</returns>
    public Task<HttpResponseMessage> PostBodyAsync(
        string uri,
        object body,
        (string key, string value)[]? headers = null,
        CancellationToken cancellationToken = default)
    {
        // Serialize body
        string serializedContent = JsonHelper.Serialize(body, new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        // Create HTTP request
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new(uri),
            Content = new StringContent(serializedContent, Encoding.UTF8, "application/json"),
        };

        if (headers is not null)
            foreach ((string key, string value) in headers)
                request.Headers.Add(key, value);

        // Send HTTP request
        logger?.LogInformation($"[RequestHelper-PostBodyAsync] Sending HTTP reuqest. POST: {uri}.");
        return httpClient.SendAsync(request, cancellationToken);
    }


    /// <summary>
    /// Sends a new POST request to the given uri with the serializes body and validates it
    /// </summary>
    /// <typeparam name="T">The Type the response data should get parsed into</typeparam>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="body">The body which should be serialized</param>
    /// <param name="headers">The optional headers for the request</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The validated HTTP response data</returns>
    public async Task<string> PostBodyAndValidateAsync(
        string uri,
        object body,
        (string key, string value)[]? headers = null,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        HttpResponseMessage httpResponse = await PostBodyAsync(uri, body, headers, cancellationToken)
            .ConfigureAwait(false);
        // Parse HTTP response data
        string httpResponseData = await httpResponse.Content.ReadAsStringAsync()
            .ConfigureAwait(false);

        // Check for exception
        if (!httpResponse.IsSuccessStatusCode)
        {
            logger?.LogError($"[RequestHelper-PostBodyAndValidateAsync] HTTP request failed. Statuscode: {httpResponse.StatusCode}.");
            throw IdentityPlatformException.FromResponseData(httpResponseData);
        }

        // Return response data
        return httpResponseData;
    }


    /// <summary>
    /// Sends a new POST request to the given uri with the serializes body, validates it and parses it
    /// </summary>
    /// <typeparam name="T">The Type the response data should get parsed into</typeparam>
    /// <param name="uri">The uri the request should be made to</param>
    /// <param name="body">The body which should be serialized</param>
    /// <param name="headers">The optional headers for the request</param>
    /// <param name="cancellationToken">The cancellation token to cancel the action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    /// <exception cref="System.Text.Json.JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    /// <returns>The parsed Type T</returns>
    public async Task<T> PostBodyAndParseAsync<T>(
        string uri,
        object body,
        (string key, string value)[]? headers = null,
        CancellationToken cancellationToken = default)
    {
        // Send HTTP request
        string httpResponseData = await PostBodyAndValidateAsync(uri, body, headers, cancellationToken)
            .ConfigureAwait(false);

        // Parse as Type T and return
        return JsonHelper.Deserialize<T>(httpResponseData);
    }
}