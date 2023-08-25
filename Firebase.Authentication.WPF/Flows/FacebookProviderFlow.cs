using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.Flows;

/// <summary>
/// Handles Facebook OAuth authentication with a new window
/// </summary>
public class FacebookProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new FacebookProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "https://localhost/") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Facebook,
                windowSize: (685, 590),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new FacebookProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost/") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Facebook,
                windowSize: (685, 590),
                redirectTo: redirectTo,
                logger: logger)
    { }
}