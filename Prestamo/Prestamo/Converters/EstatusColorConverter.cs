using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class EstatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string estatus)
            {
                switch (estatus.ToLower())
                {
                    case "pagado":
                        return Color.Green;
                    case "pendiente":
                        return Color.Yellow;
                    case "retraso":
                        return Color.Red;
                }
            }
            return Color.Default; // Color por defecto si no coincide con ninguna opción
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
