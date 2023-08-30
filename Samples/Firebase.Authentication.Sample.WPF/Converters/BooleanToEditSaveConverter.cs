using System.Globalization;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class BooleanToEditSaveConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? "Save" : "Edit";
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (string)value == "Save";
    }
}