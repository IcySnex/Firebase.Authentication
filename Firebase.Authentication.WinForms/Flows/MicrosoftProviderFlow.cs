using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Firebase.Authentication.WinForms.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WinForms.Flows;

/// <summary>
/// Handles Microsoft OAuth authentication with a new form
/// </summary>
public class MicrosoftProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new MicrosoftProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public MicrosoftProviderFlow(
        FormConfig formConfig,
        string redirectTo = "http://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Microsoft,
                formSize: (430, 625),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new MicrosoftProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public MicrosoftProviderFlow(
        FormConfig formConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "http://localhost") :
            base(
                formConfig: formConfig,
                provider: Provider.Microsoft,
                formSize: (430, 625),
                redirectTo: redirectTo,
                logger: logger)
    { }
}