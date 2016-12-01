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
        private IMobileServiceTable<Bache> tablaBache;        

        public Task<IEnumerable<Bache>> GetBaches()
        {
            tablaBache = clienteAzure.GetTable<Bache>();
            tablaBache.WithParameters(parametroHeader);
            return  tablaBache.ToEnumerableAsync();
        }

        public void AddBaches(Bache bache)
        {
            tablaBache = clienteAzure.GetTable<Bache>();
            tablaBache.WithParameters(parametroHeader);
            tablaBache.InsertAsync(bache);
        }
    }
}
