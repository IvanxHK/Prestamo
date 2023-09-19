using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.ToString() == String.Empty) value = 0m;
            NumberFormatInfo nfi = new CultureInfo("es-MX").NumberFormat;
            return Regex.Replace(Decimal.Parse(value.ToString()).ToString("C", nfi), "\\.00$", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
