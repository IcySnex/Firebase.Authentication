using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.WPF.Internal;

/// <summary>
/// Handles 3rd party OAuth provider authentication with a new window
/// </summary>
public abstract class ProviderFlow : IProviderFlow
{
    readonly Provider provider;

    readonly ILogger<IProviderFlow>? logger;

    /// <summary>
    /// Creates a new ProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    public ProviderFlow(
        WindowConfig windowConfig,
        Provider provider)
    {
        WindowConfiguration = windowConfig;
        this.provider = provider;
    }

    /// <summary>
    /// Creates a new ProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="logger">The logger which will be used to log</param>
    public ProviderFlow(
        WindowConfig windowConfig,
        Provider provider,
        ILogger<IProviderFlow> logger)
    {
        WindowConfiguration = windowConfig;
        this.provider = provider;

        this.logger = logger;
        logger.LogInformation("[ProviderFlow-.ctor] ProviderFlow has been initialized.");
    }


    /// <summary>
    /// The window configuration used for this provider flow
    /// </summary>
    public WindowConfig WindowConfiguration { get; set; }


    public async Task SignInAsync(
        IAuthenticationClient Authentication,
        CancellationToken cancellationToken = default)
    {
        // Create provider url
        ProviderRedirect redirect = await Authentication.CreateProviderRedirectAsync(provider, "http://localhost", cancellationToken);

        // Authentication
        logger?.LogInformation("[AuthenticationFlow-SignInAsync] Preparing WebView.");
        string redirectedUrl = "";

        // Sign in
        SignInRequest request = SignInRequest.WithProviderRedirect(redirectedUrl, redirect.SessionId);
        await Authentication.SignInAsync(request, cancellationToken);
    }
}