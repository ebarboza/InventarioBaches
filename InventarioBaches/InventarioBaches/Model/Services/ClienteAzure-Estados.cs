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
        private IMobileServiceTable<Estado> tablaEstado;

        public Task<IEnumerable<Estado>> GetEstados()
        {
            tablaEstado = clienteAzure.GetTable<Estado>();
            tablaEstado.WithParameters(parametroHeader);
            return tablaEstado.ToEnumerableAsync();
        }
    }
}
