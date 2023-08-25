﻿using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Client;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.Flows;

/// <summary>
/// Handles Yahoo OAuth authentication with a new window
/// </summary>
public class YahooProviderFlow : ProviderFlow
{
    /// <summary>
    /// Creates a new YahooProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        WindowConfig windowConfig,
        string redirectTo = "https://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Yahoo,
                windowSize: (430, 640),
                redirectTo: redirectTo)
    { }

    /// <summary>
    /// Creates a new YahooProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public YahooProviderFlow(
        WindowConfig windowConfig,
        ILogger<IProviderFlow> logger,
        string redirectTo = "https://localhost") :
            base(
                windowConfig: windowConfig,
                provider: Provider.Yahoo,
                windowSize: (430, 640),
                redirectTo: redirectTo,
                logger: logger)
    { }
}