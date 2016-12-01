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
        private IMobileServiceTable<Distrito> tablaDistrito;

        public Task<IEnumerable<Distrito>> GetDistritos()
        {
            tablaDistrito = clienteAzure.GetTable<Distrito>();
            tablaDistrito.WithParameters(parametroHeader);
            return tablaDistrito.ToEnumerableAsync();
        }
    }
}
