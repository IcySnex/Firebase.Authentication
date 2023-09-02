﻿using Firebase.Authentication.Types;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class ContainsProviderToVisibilityConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return Visibility.Collapsed;

        return ((Provider[])value).Contains((Provider)parameter) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}