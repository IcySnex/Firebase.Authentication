using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.Flows;

/// <summary>
/// Handles Twitter OAuth authentication with a new window
/// </summary>
public class TwitterProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new TwitterProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public TwitterProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Twitter,
                windowSize: (720, 737),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new TwitterProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public TwitterProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Twitter,
                windowSize: (720, 737),
                redirectTo: redirectTo,
                logger: logger)
    { }
}