using System.Globalization;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class BooleanToSignUpInConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? "Sign up" : "Sign in";
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == "Sign up";
    }
}