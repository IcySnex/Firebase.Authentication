using Microsoft.UI.Xaml.Data;
using System.Globalization;

namespace Firebase.Authentication.Sample.WinUI.Converters;

public class TimeSpanConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        value is TimeSpan time ? time.ToString("hh':'mm':'ss") : null;

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
    {
        bool parsed = TimeSpan.TryParseExact((string)value, "hh':'mm':'ss", CultureInfo.CurrentCulture, TimeSpanStyles.None, out TimeSpan result);
        return parsed ? result : null;
    }
}