using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.UWP.Flows;

/// <summary>
/// Handles Facebook OAuth authentication with a new popup
/// </summary>
public class FacebookProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new FacebookProviderFlow
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        PopupConfig popupConfig,
        string redirectTo = "https://localhost/") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Facebook,
                popupSize: (685, 590),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new FacebookProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        PopupConfig popupConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost/") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Facebook,
                popupSize: (685, 590),
                redirectTo: redirectTo,
                logger: logger)
    { }
}