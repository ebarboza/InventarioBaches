using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioBaches.Model.Entities
{
    [DataTable("Distritos")]
    public class Distrito
    {
        [JsonProperty]
        public string Id { set; get; }
        [JsonProperty]
        public string Nombre { set; get; }
        [JsonProperty]
        public string IdProvincia { set; get; }
        [JsonProperty]
        public string IdCanton { set; get; }
        [Version]
        public string Version { set; get; }
    }
}
