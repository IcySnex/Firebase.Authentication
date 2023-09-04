using System.Globalization;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class TimeSpanConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        value is TimeSpan time ? time.ToString("hh':'mm':'ss") : null;

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool parsed = TimeSpan.TryParseExact((string)value, "hh':'mm':'ss", CultureInfo.CurrentCulture, TimeSpanStyles.None, out TimeSpan result);
        return parsed ? result : null;
    }
}