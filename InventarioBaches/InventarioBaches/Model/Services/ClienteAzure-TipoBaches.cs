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
        private IMobileServiceTable<TipoBache> tablaTipoBache;

        public Task<IEnumerable<TipoBache>> GetTipoBaches()
        {
            tablaTipoBache = clienteAzure.GetTable<TipoBache>();
            tablaTipoBache.WithParameters(parametroHeader);
            return tablaTipoBache.ToEnumerableAsync();
        }

    }
}
