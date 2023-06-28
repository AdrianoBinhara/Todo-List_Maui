using System;
using System.Globalization;

namespace Maui_Fun.Helpers.Converters
{
    public class TimeToLowerCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime time)
            {
                return time.ToString("hh:mm tt").ToLower();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

