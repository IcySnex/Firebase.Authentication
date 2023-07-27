using System.Net;

namespace Firebase.Authentication.Internal.HttpHandler;

/// <summary>
/// Client handler which passes requests through a given proxy
/// </summary>
internal class ProxyHttpClientHandler : HttpClientHandler
{
    /// <summary>
    /// Creates a new ProxyHttpClientHandler
    /// </summary>
    /// <param name="proxy">The proxy used for web requests</param>
    public ProxyHttpClientHandler(
        IWebProxy proxy)
    {
        UseProxy = true;
        Proxy = proxy;
    }
}