using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class RandomBackgroundColorConverter : IValueConverter
    {
        private Random random = new Random();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Genera un color aleatorio
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            return randomColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
