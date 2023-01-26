using Payments.Core.Entities;
using Payments.Core.Interfaces.Repository;
using Payments.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Services
{
    public class CatalogService : ICatalogService
    {

        private readonly ICatalogRespository respository;

        public CatalogService(ICatalogRespository respository)
        {
            this.respository = respository;
        }

        public async Task<IEnumerable<CURRENCY>> cuerrencyCatalog()
        {
            return await this.respository.cuerrencyCatalog();
        }

        public async Task<IEnumerable<SUPPLIER>> supplierCatalog()
        {
            return await this.respository.supplierCatalog();
        }
    }
}
