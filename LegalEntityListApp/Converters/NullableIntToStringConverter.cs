using System;
using System.Globalization;
using Xamarin.Forms;

namespace LegalEntityListApp.Converters
{
    public class NullableIntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Don't need this binding mode in current context");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? number = null;
            if (int.TryParse(value as string, out var num))
            {
                number = num;
            }
            return number;
        }
    }
}
