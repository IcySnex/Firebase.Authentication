using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinForms.Flows;

/// <summary>
/// Handles Apple OAuth authentication with a new form
/// </summary>
public class AppleProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new AppleProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public AppleProviderFlow(
        FormConfig formConfig,
        string redirectTo = "https://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Apple,
                formSize: (440, 715),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new AppleProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public AppleProviderFlow(
        FormConfig formConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Apple,
                formSize: (440, 715),
                redirectTo: redirectTo,
                logger: logger)
    { }
}