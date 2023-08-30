using System.Globalization;
using System.Windows.Data;

namespace Firebase.Authentication.Sample.WPF.Converters;

public class DateTimeDifferenceConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        TimeSpan difference = DateTime.Now - (DateTime)value;

        double totalWeeks = difference.TotalDays / 7;
        double totalMonths = totalWeeks / 4;
        double totalYears = totalMonths / 12;

        if (totalYears >= 1)
            return totalYears + " years ago";
        if (totalMonths >= 1)
            return totalMonths + " months ago";
        if (totalWeeks >= 1)
            return totalWeeks + " weeks ago";
        if (difference.Days > 0)
            return difference.Days + " days ago";
        if (difference.Hours > 0)
            return difference.Hours + " hours ago";
        if (difference.Minutes > 0)
            return difference.Minutes + " minutes ago";
        if (difference.Seconds > 0)
            return difference.Seconds + " seconds ago";

        return "now";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}