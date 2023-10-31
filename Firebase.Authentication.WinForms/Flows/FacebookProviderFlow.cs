using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinForms.Flows;

/// <summary>
/// Handles Facebook OAuth authentication with a new form
/// </summary>
public class FacebookProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new FacebookProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        FormConfig formConfig,
        string redirectTo = "https://localhost/") :
            base(
                formConfig: formConfig,
                provider: Provider.Facebook,
                formSize: (685, 590),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new FacebookProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public FacebookProviderFlow(
        FormConfig formConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost/") :
            base(
                formConfig: formConfig,
                provider: Provider.Facebook,
                formSize: (685, 590),
                redirectTo: redirectTo,
                logger: logger)
    { }
}