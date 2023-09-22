using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models
{
    public class PagoItem
    {
        public string OrdenTexto { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public long Monto { get; set; }
        public int Estatus { get; set; }
    }

}
