using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Internal;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.ProviderFlows;

/// <summary>
/// Handles Google OAuth authentication with a new window
/// </summary>
public class GoolgeProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new GoolgeProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    public GoolgeProviderFlow(
        WindowConfig windowConfig) :
            base(
                windowConfig: windowConfig,
                provider: Provider.Google,
                windowSize: (470, 700),
                redirectTo: "http://localhost")
    { }

    /// <summary>
    /// Creates a new ProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    public GoolgeProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger) :
            base(
                windowConfig: windowConfig,
                provider: Provider.Google,
                windowSize: (470, 700),
                redirectTo: "http://localhost",
                logger: logger)
    { }
}