using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinUI.Configuration;
using Firebase.Authentication.WinUI.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinUI.Flows;

/// <summary>
/// Handles Github OAuth authentication with a new window
/// </summary>
public class GithubProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new GithubProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GithubProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Github,
                windowSize: (390, 775),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new GithubProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GithubProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Github,
                windowSize: (390, 775),
                redirectTo: redirectTo,
                logger: logger)
    { }
}