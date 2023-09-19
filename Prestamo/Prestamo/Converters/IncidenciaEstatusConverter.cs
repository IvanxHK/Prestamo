using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class IncidenciaEstatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "1":
                    return "Solicitada";
                case "2":
                    return "En curso";
                case "3":
                    return "Resuelta";
                case "4":
                    return "Rechazada";
            }
            return "Solicitdad";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
