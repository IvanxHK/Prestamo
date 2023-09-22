using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models.Server
{
    public partial class SetAvalResponse
    {
        [JsonProperty("codigo")]
        public long Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("objList")]
        public SetAvalObjList ObjList { get; set; }
    }
    public partial class SetAvalObjList
    {
        [JsonProperty("pk_aval")]
        public long PkAval { get; set; }
    }
}
