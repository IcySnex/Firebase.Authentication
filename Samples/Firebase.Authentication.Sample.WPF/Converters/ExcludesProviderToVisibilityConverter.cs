using Firebase.Authentication.Types;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class ExcludesProviderToVisibilityConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return Visibility.Visible;

        return ((Provider[])value).Contains((Provider)parameter) ? Visibility.Collapsed : Visibility.Visible;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}