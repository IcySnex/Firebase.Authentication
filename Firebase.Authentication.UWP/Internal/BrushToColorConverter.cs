using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Firebase.Authentication.UWP.Internal;

internal class BrushToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SolidColorBrush brush ? brush.Color : Colors.Transparent;

    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}