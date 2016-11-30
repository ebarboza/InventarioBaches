using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioBaches.Model.Entities
{
    [DataTable("TipoBaches")]
    public class TipoBache
    {
        [JsonProperty]
        public string Id { set; get; }
        [JsonProperty]
        public string Descripcion { set;  get; }
        [Version]
        public string Version { set; get; }
    }
}
