using System.Net;

namespace Firebase.Authentication.Configuration;

/// <summary>
/// Configuration for the underlaying HTTP client which handles all web requests
/// </summary>
public class HttpConfig
{
    /// <summary>
    /// Creates a new HttpConfig
    /// </summary>
    /// <param name="timeout">The time span in which a request times out</param>
    /// <param name="proxy">The proxy used for web requests</param>
    public HttpConfig(
        TimeSpan? timeout = null,
        IWebProxy? proxy = null)
    {
        Timeout = timeout;
        Proxy = proxy;
    }


    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public TimeSpan? Timeout { get; }

    /// <summary>
    /// The proxy used for web requests
    /// </summary>
    public IWebProxy? Proxy { get; }
}
