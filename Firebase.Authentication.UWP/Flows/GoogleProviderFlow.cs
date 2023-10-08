using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.UWP.Flows;

/// <summary>
/// Handles Google OAuth authentication with a new popup
/// </summary>
public class GoogleProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new GoogleProviderFlow
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        PopupConfig popupConfig,
        string redirectTo = "http://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Google,
                popupSize: (470, 700),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new GoogleProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        PopupConfig popupConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Google,
                popupSize: (470, 700),
                redirectTo: redirectTo,
                logger: logger)
    { }
}