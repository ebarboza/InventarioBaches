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
        private IMobileServiceTable<Municipalidad> tablaMunicipalidad;

        public Task<IEnumerable<Municipalidad>> GetMunicipalidades()
        {
            tablaMunicipalidad = clienteAzure.GetTable<Municipalidad>();
            return tablaMunicipalidad.ToEnumerableAsync();
        }
    }
}
