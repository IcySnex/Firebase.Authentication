using Microsoft.Extensions.Logging;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using WinRT.Interop;
using Windows.UI.Popups;
using Windows.Foundation;
using Firebase.Authentication.Sample.WinUI.Views;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Firebase.Authentication.Sample.WinUI.Services;

/// <summary>
/// Helps maintaining windows
/// </summary>
public class WindowHelper
{
    readonly MainView mainView;
    readonly AppWindow window;
    readonly ILogger<WindowHelper> logger;

    /// <summary>
    /// Creates a new WindowHelper with with optional logging functions
    /// </summary>
    /// <param name="window">The winodw which is used in the helper</param>
    /// <param name="logger">The logger which will be used for logging</param>
    public WindowHelper(
        MainView mainView,
        ILogger<WindowHelper> logger)
    {
        HWnd = GetHWnd(mainView);
        window = AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(HWnd));
        this.mainView = mainView;
        this.logger = logger;
    }


    /// <summary>
    /// Gets the HWND of an owner window
    /// </summary>
    /// <param name="owner">The owner window</param>
    /// <returns></returns>
    public static IntPtr GetHWnd(
        Window owner) =>
        WindowNative.GetWindowHandle(owner);


    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


    /// <summary>
    /// HWND of the current main window
    /// </summary>
    public readonly IntPtr HWnd;

    /// <summary>
    /// Active logger window (null if none is active)
    /// </summary>
    public LoggerView? LoggerView = null;

    /// <summary>
    /// Creates and activates a new window which hooks to the logger events
    /// </summary>
    public void CreateLoggerView()
    {
        if (LoggerView is not null)
        {
            LoggerView.Activate();
            return;
        }

        LoggerView = new() { Title = "WinUI3 Sample (Logger) - Firebase Authentication" };

        void handler(object? s, string e) =>
            LoggerView.ContentBlock.Text += e;

        App.Sink.OnNewLog += handler;
        LoggerView.Closed += (s, e) =>
        {
            App.Sink.OnNewLog -= handler;
            LoggerView = null;
        };

        SetSize(LoggerView, 700, 400);
        LoggerView.Activate();

        logger.LogInformation("[WindowHelper-CreateLoggerView] Created new LoggerView and hooked handler");
    }


    /// <summary>
    /// Initializes a target with the current main window
    /// </summary>
    /// <param name="target">The target</param>
    public void Initialize(
        object target) =>
        InitializeWithWindow.Initialize(target, HWnd);


    /// <summary>
    /// Sets a custom icon on the current main window
    /// </summary>
    /// <param name="icon">The bitmap icon</param>
    public void SetIcon(
        Bitmap icon)
    {
        if (icon is null)
            return;

        IntPtr hicon = icon.GetHicon();

        SendMessage(HWnd, 128, (IntPtr)0, hicon);
        SendMessage(HWnd, 128, (IntPtr)1, hicon);

        logger?.LogInformation("[WindowHelper-SetIcon] Set app icon to bitmap");
    }

    /// <summary>
    /// Sets the size of the current main window
    /// </summary>
    /// <param name="width">The width of the new size</param>
    /// <param name="height">The height of the new size</param>
    public void SetSize(
        int width,
        int height)
    {
        window.Resize(new(width + 16, height + 39));

        logger.LogInformation("[WindowHelper-SetSize] Set window size [{width}x{height}]", width, height);
    }
    /// <summary>
    /// Sets the size of the given window
    /// </summary>
    /// <param name="externalWindow">The window to set the size to</param>
    /// <param name="width">The width of the new size</param>
    /// <param name="height">The height of the new size</param>
    public void SetSize(
        Window externalWindow,
        int width,
        int height)
    {
        IntPtr hWnd = WindowNative.GetWindowHandle(externalWindow);
        AppWindow window = AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(hWnd));

        window.Resize(new(width, height));

        logger.LogInformation("Set external window size [{width}x{height}]", width, height);
    }

    /// <summary>
    /// Sets an UIElement as a custom title bar on the current main window
    /// </summary>
    /// <param name="titleBar">The UIElement to set as a title bar</param>
    /// <param name="container">The container UIElement of the title bar to update visibilies</param>
    /// <returns>A boolean wether the UIElement was set as the custom title bar successfully</returns>
    public bool SetTitleBar(
        UIElement? titleBar,
        UIElement? container = null)
    {
        try
        {
            if (titleBar is null)
            {
                if (container is not null)
                    container.Visibility = Visibility.Collapsed;

                mainView.ExtendsContentIntoTitleBar = false;
                mainView.SetTitleBar(null);

                logger.LogInformation("[WindowHelper-SetTitleBar] Removed custom TitleBar");
                return true;
            }

            if (container is not null)
                container.Visibility = Visibility.Visible;

            mainView.ExtendsContentIntoTitleBar = true;
            mainView.SetTitleBar(titleBar);

            logger.LogInformation("[WindowHelper-SetTitleBar] Set custom TitleBar");
            return true;
        }
        catch (Exception ex)
        {
            logger.LogInformation("Failed to set custom TitleBar", ex);
            return false;
        }
    }


    /// <summary>
    /// Dispalys a ContentDialog
    /// </summary>
    /// <param name="dialog">The dialog to display</param>
    public IAsyncOperation<ContentDialogResult> AlertAsync(
        ContentDialog dialog)
    {
        foreach (Popup popup in VisualTreeHelper.GetOpenPopupsForXamlRoot(mainView.Content.XamlRoot))
            if (popup.Child is ContentDialog openDialog)
                openDialog.Hide();

        dialog.XamlRoot = mainView.Content.XamlRoot;
        dialog.PrimaryButtonStyle = (Style)App.Current.Resources["AccentButtonStyle"];
        dialog.Style = (Style)App.Current.Resources["DefaultContentDialogStyle"];


        return dialog.ShowAsync();
    }

    /// <summary>
    /// Creates a new ContentDialog which displays the content and title and logs the message
    /// </summary>
    /// <param name="content">The content of the dialog</param>
    /// <param name="title">The title of the dialog</param>
    public IAsyncOperation<ContentDialogResult> AlertAsync(
        object content,
        string? title = null,
        string? closeButton = "Ok",
        string? primaryButton = null)
    {
        ContentDialog dialog = new()
        {
            Content = content,
            Title = title is null ? null : title + "!",
            CloseButtonText = closeButton,
            PrimaryButtonText = primaryButton
        };
        return AlertAsync(dialog);
    }

    /// <summary>
    /// Creates a new ContentDialog which displays the content and title and logs the message
    /// </summary>
    /// <param name="message">The content of the dialog</param>
    /// <param name="title">The title of the dialog</param>
    public IAsyncOperation<ContentDialogResult> AlertErrorAsync(
        string message,
        string title,
        string caller)
    {
        logger.LogError($"[{caller}] {title}: {message}");
        return AlertAsync(message, "Error: " + title);
    }

    /// <summary>
    /// Creates a new ContentDialog which displays the content and title and logs the message
    /// </summary>
    /// <param name="ex">The content of the dialog</param>
    /// <param name="title">The title of the dialog</param>
    public IAsyncOperation<ContentDialogResult> AlertErrorAsync(
        Exception ex,
        string title,
        string caller) =>
        AlertErrorAsync(ex.Message, title, caller);
}