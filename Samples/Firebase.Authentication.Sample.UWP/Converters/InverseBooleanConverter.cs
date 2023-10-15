#nullable enable

using System;
using Windows.UI.Xaml.Data;

namespace Firebase.Authentication.Sample.UWP.Converters;

public class InverseBooleanConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        !(bool)value;

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        !(bool)value;
}