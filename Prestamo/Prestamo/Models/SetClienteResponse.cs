using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models
{
    public partial class SetClienteResponse
    {
        [JsonProperty("codigo")]
        public long Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("objList")]
        public SetClienteObjList ObjList { get; set; }
    }
    public partial class SetClienteObjList
    {
        [JsonProperty("pk_cliente")]
        public long PkCliente { get; set; }
    }
}
