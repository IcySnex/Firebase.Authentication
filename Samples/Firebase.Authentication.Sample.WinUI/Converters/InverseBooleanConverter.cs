using Microsoft.UI.Xaml.Data;
using System.Globalization;

namespace Firebase.Authentication.Sample.WinUI.Converters;

public class InverseBooleanConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        !(bool)value;

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        !(bool)value;
}