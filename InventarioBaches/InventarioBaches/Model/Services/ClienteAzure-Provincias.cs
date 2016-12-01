using InventarioBaches.Model.Entities;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioBaches.Model.Services
{    
    public partial class ClienteAzure
    {
        private IMobileServiceTable<Provincia> tablaProvincia;

        public Task<IEnumerable<Provincia>> GeProvincias()
        {
            tablaProvincia = clienteAzure.GetTable<Provincia>();
            tablaProvincia.WithParameters(parametroHeader);
            return tablaProvincia.ToEnumerableAsync();
        }
    }
}
