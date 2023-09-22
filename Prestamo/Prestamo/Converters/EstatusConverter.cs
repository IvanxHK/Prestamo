using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class EstatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int estatus)
            {
                switch (estatus)
                {
                    case 0:
                        return "No pagado sin vencer";
                    case 1:
                        return "Pagado";
                    case 2:
                        return "No pagado vencido";
                    default:
                        return "Desconocido";
                }
            }
            return "Desconocido";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
