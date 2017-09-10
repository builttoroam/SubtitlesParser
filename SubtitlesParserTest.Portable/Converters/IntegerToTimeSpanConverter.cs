using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace SubtitlesParserTest.Portable.Converters
{
    public class IntegerToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine($"Seconds: {value}");
            TimeSpan result = TimeSpan.FromMilliseconds((int)value);
            if (result != null)
            {
                return result.ToString("g");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
