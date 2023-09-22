using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.Models.Server
{
    public partial class LoginResponse
    {
        [JsonProperty("codigo")]
        public long Codigo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("objList")]
        public LoginObjList ObjList { get; set; }
    }

    public partial class LoginObjList
    {
        [JsonProperty("existe")]
        public long Existe { get; set; }

        [JsonProperty("nivel")]
        public long Nivel { get; set; }
    }
}

