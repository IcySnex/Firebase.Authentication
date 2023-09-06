using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace Firebase.Authentication.WinUI.Internal;

internal class BrushToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SolidColorBrush brush ? brush.Color : Colors.Transparent;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}