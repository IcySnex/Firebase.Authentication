using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinForms.Flows;

/// <summary>
/// Handles Google OAuth authentication with a new form
/// </summary>
public class GoogleProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new GoogleProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        FormConfig formConfig,
        string redirectTo = "http://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Google,
                formSize: (470, 700),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new GoogleProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public GoogleProviderFlow(
        FormConfig formConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Google,
                formSize: (470, 700),
                redirectTo: redirectTo,
                logger: logger)
    { }
}