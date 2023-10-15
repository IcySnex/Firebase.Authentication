#nullable enable

using System;
using Windows.UI.Xaml.Data;

namespace Firebase.Authentication.Sample.UWP.Converters;

public class EmailVerifiedConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        (bool)value ? "Email (Verified)" : "Email (Unverified)";

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        (string)value == "Email (Verified)";
}