namespace Firebase.Authentication.Configuration;

/// <summary>
/// Configuration for the Firebase Authentication API
/// </summary>
public class AuthenticationConfig
{
    /// <summary>
    /// Creates a new AuthenticationConfig
    /// </summary>
    /// <param name="apiKey">The Firebase Web API key</param>
    /// <param name="httpConfiguration">Configuration for the underlaying HTTP client which handles all web requests</param>
    public AuthenticationConfig(
        string apiKey,
        HttpConfig? httpConfiguration = null)
    {
        ApiKey = apiKey;
        HttpConfiguration = httpConfiguration ?? new();
    }


    /// <summary>
    /// The Firebase Web API key
    /// </summary>
    public string ApiKey { get; }

    /// <summary>
    /// The Configuration for the underlaying HTTP client which handles all web requests
    /// </summary>
    public HttpConfig HttpConfiguration { get; }
}