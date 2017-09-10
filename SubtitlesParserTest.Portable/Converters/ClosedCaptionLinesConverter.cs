using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace SubtitlesParserTest.Portable.Converters
{
    public class ClosedCaptionLinesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lines = value as List<string>;
            if(value != null)
            {
                return string.Join(Environment.NewLine, lines);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
