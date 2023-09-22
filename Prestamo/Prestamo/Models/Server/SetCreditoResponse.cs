using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models.Server
{
    public partial class SetCreditoResponse
    {
        [JsonProperty("codigo")]
        public long Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("objList")]
        public SetCreditoObjList ObjList { get; set; }
    }
    public partial class SetCreditoObjList
    {
        [JsonProperty("pk_credito")]
        public long PkCredito { get; set; }

        [JsonProperty("pagos")]
        public List<Pago> Pagos { get; set; }
    }

    public partial class Pago
    {
        [JsonProperty("pk_credito_detalle")]
        public long PkCreditoDetalle { get; set; }

        [JsonProperty("orden")]
        public long Orden { get; set; }

        [JsonProperty("orden_texto")]
        public string OrdenTexto { get; set; }

        [JsonProperty("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonProperty("monto")]
        public long Monto { get; set; }

        [JsonProperty("estatus")]
        public int Estatus { get; set; }
    }
}
