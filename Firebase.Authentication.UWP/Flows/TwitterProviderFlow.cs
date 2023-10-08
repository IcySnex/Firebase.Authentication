using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.UWP.Configuration;
using Firebase.Authentication.UWP.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.UWP.Flows;

/// <summary>
/// Handles Twitter OAuth authentication with a new popup
/// </summary>
public class TwitterProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new TwitterProviderFlow
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public TwitterProviderFlow(
        PopupConfig popupConfig,
        string redirectTo = "http://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Twitter,
                popupSize: (720, 737),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new TwitterProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public TwitterProviderFlow(
        PopupConfig popupConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                popupConfig: popupConfig,
                provider: Provider.Twitter,
                popupSize: (720, 737),
                redirectTo: redirectTo,
                logger: logger)
    { }
}