using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WinForms.Helpers;

public static class Extensions
{
    public static void LogInformationAndShow(
        this ILogger logger,
        string message,
        string title,
        string caller)
    {
        logger.LogInformation($"[{caller}] {title}: {message}");
        MessageBox.Show(message, title + "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    public static void LogErrorAndShow(
        this ILogger logger,
        string message,
        string title,
        string caller)
    {
        logger.LogError($"[{caller}] {title}: {message}");
        MessageBox.Show(message, title + "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void LogErrorAndShow(
        this ILogger logger,
        Exception exception,
        string title,
        string caller)
    {
        logger.LogError($"[{caller}] {title}: {exception.Message}");
        MessageBox.Show(exception.Message, title + "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}