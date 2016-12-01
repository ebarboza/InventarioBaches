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
        private IMobileServiceTable<Canton> tablaCanton;

        public Task<IEnumerable<Canton>> GetCantones()
        {
            tablaCanton = clienteAzure.GetTable<Canton>();
            tablaCanton.WithParameters(parametroHeader);
            return tablaCanton.ToEnumerableAsync();
        }

    }
}
