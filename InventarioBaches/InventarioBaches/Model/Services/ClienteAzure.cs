using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using InventarioBaches.Model.Entities;

namespace InventarioBaches.Model.Services
{
    public partial class ClienteAzure
    {
        private IMobileServiceClient clienteAzure;
        private Dictionary<string, string> parametroHeader;

        public ClienteAzure()
        {
            clienteAzure = new MobileServiceClient("http://reportebaches.azurewebsites.net");
            parametroHeader = new Dictionary<string, string>() { { "ZUMO-API-VERSION", "2.0.0" } };
        }          
    }
}
