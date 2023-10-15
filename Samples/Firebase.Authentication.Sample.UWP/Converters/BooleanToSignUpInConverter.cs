#nullable enable

using System;
using Windows.UI.Xaml.Data;

namespace Firebase.Authentication.Sample.UWP.Converters;

public class BooleanToSignUpInConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        (bool)value ? "Sign up" : "Sign in";

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        (string)value == "Save";
}