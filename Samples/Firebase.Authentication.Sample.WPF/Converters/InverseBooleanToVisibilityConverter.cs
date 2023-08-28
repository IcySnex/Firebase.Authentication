﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class InverseBooleanToVisibilityConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? Visibility.Collapsed : Visibility.Visible;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (Visibility)value == Visibility.Collapsed;
    }
}