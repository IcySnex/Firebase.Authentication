using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using Firebase.Authentication.WPF.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System.Windows;

namespace Firebase.Authentication.WPF.Client;

/// <summary>
/// Handles 3rd party OAuth provider authentication with a new window
/// </summary>
public abstract class ProviderFlow : IProviderFlow
{
    readonly Provider provider;
    readonly (int width, int height) windowSize;
    string redirectTo;

    readonly ILogger<IProviderFlow>? logger;

    /// <summary>
    /// Creates a new ProviderFlow
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="windowSize">The size of the provider flow window</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        WindowConfig windowConfig,
        Provider provider,
        (int width, int height) windowSize,
        string redirectTo)
    {
        WindowConfiguration = windowConfig;
        this.provider = provider;
        this.windowSize = windowSize;
        this.redirectTo = redirectTo;
    }

    /// <summary>
    /// Creates a new ProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="windowConfig">The configuration the provider flow window will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="windowSize">The size of the provider flow window</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        WindowConfig windowConfig,
        Provider provider,
        (int width, int height) windowSize,
        string redirectTo,
        ILogger<IProviderFlow> logger)
    {
        WindowConfiguration = windowConfig;
        this.provider = provider;
        this.windowSize = windowSize;
        this.redirectTo = redirectTo;

        this.logger = logger;
        logger.LogInformation("[ProviderFlow-.ctor] ProviderFlow has been initialized.");
    }


    /// <summary>
    /// The window configuration used for this provider flow
    /// </summary>
    public WindowConfig WindowConfiguration { get; set; }


    Window window = default!;
    WebView2 webView = default!;

    void CreateWindowAndWebView()
    {
        webView = new();
        window = new()
        {
            Title = WindowConfiguration.Title,
            Icon = WindowConfiguration.Icon,
            Owner = WindowConfiguration.Owner,
            Left = WindowConfiguration.Left,
            Top = WindowConfiguration.Top,
            WindowStartupLocation = WindowConfiguration.StartupLocation,
            Width = windowSize.width,
            Height = windowSize.height,
            ResizeMode = ResizeMode.NoResize,
            Content = webView
        };

        logger?.LogInformation("[ProviderFlow-CreateWindowAndWebView] Created provider flow window with webView");
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
        logger?.LogInformation($"[ProviderFlow-SignInAsync] Provider ({provider}) flow authenticaion requested.");
        ProviderRedirect redirect = await authentication.CreateProviderRedirectAsync(provider, redirectTo, cancellationToken);

        // Define result
        string? redirectedUrl = null;
        TaskCompletionSource<string> taskWaiter = new();

        // Create cancellation token based on timeout
        CancellationTokenSource cancelSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancelSource.Token.Register(() =>
        {
            taskWaiter.TrySetCanceled();
            window?.Dispatcher.BeginInvoke(window.Close);

            logger?.LogInformation($"[ProviderFlow-OnTokenCancelled] Provider ({provider}) flow authenticaion was cancelled");
        });


        // Create UI
        CreateWindowAndWebView();

        window.Closed += OnWindowClosed;
        void OnWindowClosed(object? _, object _1)
        {
            window.Closed -= OnWindowClosed;

            // Clear cache
            webView.CoreWebView2.Profile.ClearBrowsingDataAsync();
            webView.Dispose();

            // Clear UI
            window = default!;
            webView = default!;

            // If redirectedUrl stil not set cancel
            if (redirectedUrl is null)
                cancelSource.Cancel();
            cancelSource.Dispose();


            logger?.LogInformation("[ProviderFlow-OnWindowClosed] Provider flow window was closed and objects were disposed");
        }

        if (WindowConfiguration.ShowAsDialog)
            await Task.Run(() => window.Dispatcher.BeginInvoke(window.ShowDialog));
        else
            window.Show();


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
            {
                taskWaiter.SetResult(e.Uri);
            }
        }

        if (provider == Provider.Facebook)
            webView.CoreWebView2.NavigationCompleted += async (s, e) => await webView.CoreWebView2.ExecuteScriptAsync("document.querySelector(`button[title=\"Decline optional cookies\"]`)?.click()");


        // Authenticate
        webView.CoreWebView2.Navigate(redirect.Uri);
        redirectedUrl = await taskWaiter.Task;
        window.Close();

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