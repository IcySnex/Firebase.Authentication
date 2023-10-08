#nullable enable

using System.Threading.Tasks;
using System.Threading;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using Firebase.Authentication.UWP.Configuration;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Firebase.Authentication.UWP.Internal;
using Windows.UI.Xaml.Media.Animation;
using Firebase.Authentication.Models;
using Windows.UI.Core;
using System;
using Microsoft.Web.WebView2.Core;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.UWP.Client;

/// <summary>
/// Handles 3rd party OAuth provider authentication with a new popup
/// </summary>
public abstract class ProviderFlow : IProviderFlow
{
    readonly Provider provider;
    readonly (int width, int height) popupSize;
    string redirectTo;

    readonly ILogger<IProviderFlow>? logger;

    /// <summary>
    /// Creates a new ProviderFlow
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="popupSize">The size of the provider flow popup</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        PopupConfig popupConfig,
        Provider provider,
        (int width, int height) popupSize,
        string redirectTo)
    {
        PopupConfiguration = popupConfig;
        this.provider = provider;
        this.popupSize = popupSize;
        this.redirectTo = redirectTo;
    }

    /// <summary>
    /// Creates a new ProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="popupConfig">The configuration the provider flow popup will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="popupSize">The logger which will be used to log</param>
    /// <param name="popupSize">The size of the provider flow popup</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        PopupConfig popupConfig,
        Provider provider,
        (int width, int height) popupSize,
        string redirectTo,
        ILogger<IProviderFlow> logger)
    {
        PopupConfiguration = popupConfig;
        this.provider = provider;
        this.popupSize = popupSize;
        this.redirectTo = redirectTo;

        this.logger = logger;
        logger.LogInformation("[ProviderFlow-.ctor] ProviderFlow has been initialized.");
    }


    /// <summary>
    /// The popup configuration used for this provider flow
    /// </summary>
    public PopupConfig PopupConfiguration { get; set; }


    Popup popup = default!;
    WindowPopup popupContent = default!;
    WebView2 webView = default!;

    void CreatePopupAndWebView()
    {
        webView = new();
        popupContent = new(webView, PopupConfiguration);
        popup = new()
        {
            ChildTransitions = { new PopupThemeTransition() { FromVerticalOffset = 128 } },
            Child = popupContent
        };

        popupContent.Resize(popupSize.width, popupSize.height);

        logger?.LogInformation("[ProviderFlow-CreatePopupAndWebView] Created provider flow popup with webView");
    }


    /// <summary>
    /// Authenticates the given client with this provider flow
    /// </summary>
    /// <param name="authentication">The authentication client to authenticate</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    async Task<(string redirectedUrl, string sessionId)> AuthenticateAsync(
        IAuthenticationClient authentication,
        CancellationToken cancellationToken = default)
    {
        logger?.LogInformation($"[ProviderFlow-SignInAsync] Provider ({provider}) flow Authentication requested.");
        ProviderRedirect redirect = await authentication.CreateProviderRedirectAsync(provider, redirectTo, cancellationToken);

        // Define result
        string? redirectedUrl = null;
        TaskCompletionSource<string> taskWaiter = new();

        // Create cancellation token based on timeout
        CancellationTokenSource cancelSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancelSource.Token.Register(() =>
        {
            taskWaiter.TrySetCanceled();
            popup?.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => popup.IsOpen = false);

            logger?.LogInformation($"[ProviderFlow-OnTokenCancelled] Provider ({provider}) flow Authentication was cancelled");
        });


        // Create UI
        CreatePopupAndWebView();

        popup.Closed += OnPopupClosed;
        async void OnPopupClosed(object? _, object _1)
        {
            popup.Closed -= OnPopupClosed;

            // Clear cache
            //webView.CoreWebView2.Profile.ClearBrowsingDataAsync().AsTask();
            await webView.CoreWebView2.Profile.ClearBrowsingDataAsync();
            webView.Close();

            // Clear UI
            popup = default!;
            popupContent = default!;
            webView = default!;

            // If redirectedUrl stil not set cancel
            if (redirectedUrl is null)
                cancelSource.Cancel();
            cancelSource.Dispose();


            logger?.LogInformation("[ProviderFlow-OnWindowClosed] Provider flow popup was closed and objects were disposed");
        }

        popup.IsOpen = true;


        // Setup WebView
        logger?.LogInformation("[ProviderFlow-SignInAsync] Setting up WebView2");

        await webView.EnsureCoreWebView2Async();

        webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        webView.CoreWebView2.Settings.IsZoomControlEnabled = false;
        webView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
        webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

        webView.CoreWebView2.NavigationStarting += NavigationStarting;
        void NavigationStarting(object? _, CoreWebView2NavigationStartingEventArgs e)
        {
            // If navigation contains redirected back url set result
            if (e.Uri.StartsWith(redirectTo))
                taskWaiter.SetResult(e.Uri);
        }

        if (provider == Provider.Facebook)
            webView.CoreWebView2.NavigationCompleted += async (s, e) => await webView.CoreWebView2.ExecuteScriptAsync("document.querySelector(`button[title=\"Decline optional cookies\"]`)?.click()");


        // Authenticate
        webView.CoreWebView2.Navigate(redirect.Uri);
        redirectedUrl = await taskWaiter.Task;
        popup.IsOpen = false;

        logger?.LogInformation("[ProviderFlow-SignInAsync] Provider flow was successfully authenticated");
        return (redirectedUrl, redirect.SessionId);
    }


    /// <summary>
    /// Signs in the given client with this provider flow
    /// </summary>
    /// <param name="authentication">The authentication client to sign into</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task SignInAsync(
        IAuthenticationClient authentication,
        CancellationToken cancellationToken = default)
    {
        // Authenticate
        (string redirectedUrl, string sessionId) providerInfo = await AuthenticateAsync(authentication, cancellationToken);

        // Sign in
        SignInRequest request = SignInRequest.WithProviderRedirect(providerInfo.redirectedUrl, providerInfo.sessionId);
        await authentication.SignInAsync(request, cancellationToken);
    }

    /// <summary>
    /// Links the current user of the given client with this provider flow
    /// </summary>
    /// <param name="authentication">The authentication client to sign into</param>
    /// <param name="cancellationToken">The token to cancel this action</param>
    /// <exception cref="Firebase.Authentication.Exceptions.CredentialAlreadyExistException">Occurrs when the current credential is not null</exception>
    /// <exception cref="Firebase.Authentication.Exceptions.IdentityPlatformException">Occurs when the request failed on the Firebase Server</exception>
    /// <exception cref="System.NotSupportedException">May occurs when the json serialization fails</exception>
    /// <exception cref="System.InvalidOperationException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">May occurs when sending the web request fails</exception>
    /// <exception cref="System.Threading.Tasks.TaskCanceledException">Occurs when The task was cancelled</exception>
    public async Task LinkAsync(
        IAuthenticationClient authentication,
        CancellationToken cancellationToken = default)
    {
        // Authenticate
        (string redirectedUrl, string sessionId) providerInfo = await AuthenticateAsync(authentication, cancellationToken);

        // Link
        LinkRequest request = LinkRequest.ToProviderRedirect(providerInfo.redirectedUrl, providerInfo.sessionId);
        await authentication.LinkAsync(request, cancellationToken);
    }
}