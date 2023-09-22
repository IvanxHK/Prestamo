using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models.Server
{
    public partial class OperacionResponse
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("objList")]
        public object ObjList { get; set; }
    }

}
