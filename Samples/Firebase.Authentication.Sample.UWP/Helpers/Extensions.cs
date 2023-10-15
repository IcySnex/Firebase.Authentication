#nullable enable

using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;

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
}