using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using Firebase.Authentication.WinForms.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Firebase.Authentication.WinForms.Client;

/// <summary>
/// Handles 3rd party OAuth provider authentication with a new form
/// </summary>
public class ProviderFlow : IProviderFlow
{
    readonly Provider provider;
    readonly (int width, int height) formSize;
    readonly string redirectTo;

    readonly ILogger<IProviderFlow>? logger;

    /// <summary>
    /// Creates a new ProviderFlow
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="formSize">The size of the provider flow form</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        FormConfig formConfig,
        Provider provider,
        (int width, int height) formSize,
        string redirectTo)
    {
        FormConfiguration = formConfig;
        this.provider = provider;
        this.formSize = formSize;
        this.redirectTo = redirectTo;
    }

    /// <summary>
    /// Creates a new ProviderFlow with extendended logging functions
    /// </summary>
    /// <param name="formConfig">The configuration the provider flow form will be created with</param>
    /// <param name="provider">The provider used for this flow</param>
    /// <param name="logger">The logger which will be used to log</param>
    /// <param name="formSize">The size of the provider flow form</param>
    /// <param name="redirectTo">The url to which the provider will redirect the user back to</param>
    public ProviderFlow(
        FormConfig formConfig,
        Provider provider,
        (int width, int height) formSize,
        string redirectTo,
        ILogger<IProviderFlow> logger)
    {
        FormConfiguration = formConfig;
        this.provider = provider;
        this.formSize = formSize;
        this.redirectTo = redirectTo;

        this.logger = logger;
        logger.LogInformation("[ProviderFlow-.ctor] ProviderFlow has been initialized.");
    }


    /// <summary>
    /// The form configuration used for this provider flow
    /// </summary>
    public FormConfig FormConfiguration { get; set; }


    Form form = default!;
    WebView2 webView = default!;

    void CreateFormAndWebView()
    {
        webView = new()
        {
            Width = formSize.width,
            Height = formSize.height
        };
        form = new()
        {
            Text = FormConfiguration.Title,
            Icon = FormConfiguration.Icon,
            Owner = FormConfiguration.Parent,
            Left = FormConfiguration.Left,
            Top = FormConfiguration.Top,
            StartPosition = FormConfiguration.StartPosition,
            Width = formSize.width,
            Height = formSize.height,
            FormBorderStyle = FormBorderStyle.FixedSingle,
            MaximizeBox = false,
            MinimizeBox = false
        };
        form.Controls.Add(webView);

        logger?.LogInformation("[ProviderFlow-CreateFormAndWebView] Created provider flow form with webView");
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
            form?.BeginInvoke(() => form.Close());

            logger?.LogInformation($"[ProviderFlow-OnTokenCancelled] Provider ({provider}) flow Authentication was cancelled");
        });


        // Create UI
        CreateFormAndWebView();

        form.Closed += OnFormClosed;
        void OnFormClosed(object? _, object _1)
        {
            form.Closed -= OnFormClosed;

            // Clear cache
            webView.CoreWebView2.Profile.ClearBrowsingDataAsync();
            webView.Dispose();

            // Clear UI
            form = default!;
            webView = default!;

            // If redirectedUrl stil not set cancel
            if (redirectedUrl is null)
                cancelSource.Cancel();
            cancelSource.Dispose();


            logger?.LogInformation("[ProviderFlow-OnWindowClosed] Provider flow window was closed and objects were disposed");
        }

        if (FormConfiguration.ShowAsDialog && FormConfiguration.Parent is not null)
            await Task.Run(() => FormConfiguration.Parent.BeginInvoke(() => form.ShowDialog()));
        else
            form.Show();


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
        form.Close();

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