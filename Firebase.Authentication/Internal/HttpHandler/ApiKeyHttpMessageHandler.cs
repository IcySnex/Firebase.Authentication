namespace Firebase.Authentication.Internal.HttpHandler;

/// <summary>
/// Delegating handler which adds the API key to every request
/// </summary>
internal class ApiKeyHttpDelegatingHandler : DelegatingHandler
{
    readonly string key;

    /// <summary>
    /// Creates a new ApiKeyHtppMessageHandler
    /// </summary>
    /// <param name="key">The api key which should be added</param>
    public ApiKeyHttpDelegatingHandler(
        string key,
        HttpMessageHandler innerHandler)
    {
        this.key = key;

        InnerHandler = innerHandler;
    }


    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.RequestUri = new($"{request.RequestUri}?key={key}");

        return base.SendAsync(request, cancellationToken);
    }
}