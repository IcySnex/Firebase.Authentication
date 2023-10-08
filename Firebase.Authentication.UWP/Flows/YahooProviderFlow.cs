using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.UWP.Flows;

/// <summary>
/// Handles Yahoo OAuth authentication with a new popup
/// </summary>
public class YahooProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new YahooProviderFlow
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        PopupConfig popupConfig,
        string redirectTo = "https://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Yahoo,
                popupSize: (430, 640),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new YahooProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        PopupConfig popupConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Yahoo,
                popupSize: (430, 640),
                redirectTo: redirectTo,
                logger: logger)
    { }
}