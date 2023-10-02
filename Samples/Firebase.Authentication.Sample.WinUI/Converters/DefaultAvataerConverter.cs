using Firebase.Authentication.WinUI.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Firebase.Authentication.Sample.WinUI.Converters;

public class DefaultAvataerConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is not string url || string.IsNullOrWhiteSpace(url))
            return Icons.ToImageSource(Helpers.Icons.DefaultAvatar, 100,100);

        return new BitmapImage(new Uri(url));
    }

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is not BitmapImage bitmap)
            return null;

        return bitmap.UriSource.ToString();
    }
}