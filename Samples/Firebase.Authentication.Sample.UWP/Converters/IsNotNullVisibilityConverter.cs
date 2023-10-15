﻿#nullable enable

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Firebase.Authentication.Sample.UWP.Converters;

public class IsNotNullVisibilityConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        value is not null ? Visibility.Visible : Visibility.Collapsed;

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}