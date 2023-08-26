using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.Flows;

/// <summary>
/// Handles Google OAuth authentication with a new window
/// </summary>
public class GoogleProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new GoogleProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Google,
                windowSize: (470, 700),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new GoogleProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Google,
                windowSize: (470, 700),
                redirectTo: redirectTo,
                logger: logger)
    { }
}