using System;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class OpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color color && parameter is double opacity)
            {
                return new Color(color.R, color.G, color.B, 0.001);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You might or might not need a ConvertBack implementation depending on your use case
            throw new NotImplementedException();
        }
    }
}
