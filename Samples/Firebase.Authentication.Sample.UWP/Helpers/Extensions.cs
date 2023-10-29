#nullable enable

using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Firebase.Authentication.Sample.UWP.Helpers;

public static class Extensions
{
    public static Type? AsType(this string input,
        string assembly = "Firebase.Authentication.Sample.UWP") =>
        Type.GetType($"{assembly}.{input}, {assembly}");


    public static Visibility ContainsProviderToVisibility(
        Provider[]? providers,
        Provider provider) =>
        providers is null ? Visibility.Collapsed : providers.Contains(provider) ? Visibility.Visible : Visibility.Collapsed;

    public static Visibility ExcludesProviderToVisibility(
        Provider[]? providers,
        Provider provider) =>
        providers is null ? Visibility.Visible : providers.Contains(provider) ? Visibility.Collapsed : Visibility.Visible;


    public static IAsyncOperation<IUICommand> AlertAsync(
        string message,
        string title,
        string closeButton = "Ok",
        string? primaryButton = null)
    {
        MessageDialog dialog = new(message, title + "!");

        if (!string.IsNullOrWhiteSpace(primaryButton))
            dialog.Commands.Add(new UICommand(primaryButton));
        dialog.Commands.Add(new UICommand(closeButton));

        return dialog.ShowAsync();
    }

    public static IAsyncOperation<IUICommand> AlertErrorAsync(
        string message,
        string title,
        string caller,
        ILogger? logger = null)
    {
        logger?.LogError($"[{caller}] {title}: {message}");
        return AlertAsync(message, "Error: " + title);
    }

    public static IAsyncOperation<IUICommand> AlertErrorAsync(
        Exception ex,
        string title,
        string caller,
        ILogger? logger = null) =>
        AlertErrorAsync(ex.Message, title, caller, logger);


    public static IAsyncOperation<ContentDialogResult> ShowDialogAsync(
        ContentDialog dialog)
    {
        foreach (Popup popup in VisualTreeHelper.GetOpenPopupsForXamlRoot(Window.Current.Content.XamlRoot))
            if (popup.Child is ContentDialog openDialog)
                openDialog.Hide();

        dialog.XamlRoot = Window.Current.Content.XamlRoot;
        dialog.PrimaryButtonStyle = (Style)App.Current.Resources["AccentButtonStyle"];

        return dialog.ShowAsync();
    }

    public static IAsyncOperation<ContentDialogResult> ShowDialogAsync(
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
        return ShowDialogAsync(dialog);
    }
}