using Microsoft.Extensions.Logging;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF.Helpers;

public static class Extensions
{
    public static void LogInformationAndShow(this ILogger logger,
        string message,
        string title,
        string caller)
    {
        logger.LogInformation($"[{caller}] {title}: {message}");
        MessageBox.Show(message, title + "!", MessageBoxButton.OK, MessageBoxImage.Information);
    }


    public static void LogErrorAndShow(this ILogger logger,
        string message,
        string title,
        string caller)
    {
        logger.LogError($"[{caller}] {title}: {message}");
        MessageBox.Show(message, title + "!", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public static void LogErrorAndShow(this ILogger logger,
        Exception exception,
        string title,
        string caller)
    {
        logger.LogError($"[{caller}] {title}: {exception.Message}");
        MessageBox.Show(exception.Message, title + "!", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}