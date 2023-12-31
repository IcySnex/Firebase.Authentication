﻿using System.Globalization;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class BooleanToChangeSaveConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        (bool)value ? "Save" : "Change";

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        (string)value == "Save";
}