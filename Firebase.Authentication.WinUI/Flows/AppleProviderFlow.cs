using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinUI.Configuration;
using Firebase.Authentication.WinUI.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinUI.Flows;

/// <summary>
/// Handles Apple OAuth authentication with a new window
/// </summary>
public class AppleProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new AppleProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public AppleProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "https://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Apple,
                windowSize: (440, 715),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new AppleProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public AppleProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Apple,
                windowSize: (440, 715),
                redirectTo: redirectTo,
                logger: logger)
    { }
}