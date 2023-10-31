using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinForms.Flows;

/// <summary>
/// Handles Yahoo OAuth authentication with a new form
/// </summary>
public class YahooProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new YahooProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        FormConfig formConfig,
        string redirectTo = "https://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Yahoo,
                formSize: (430, 640),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new YahooProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        FormConfig formConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Yahoo,
                formSize: (430, 640),
                redirectTo: redirectTo,
                logger: logger)
    { }
}