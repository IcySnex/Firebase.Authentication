using Microsoft.UI.Xaml.Data;

namespace Firebase.Authentication.Sample.WinUI.Converters;

public class BooleanToChangeSaveConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language) =>
        (bool)value ? "Save" : "Change";

    public object? ConvertBack(object value, Type targetType, object parameter, string language) =>
        (string)value == "Save";
}