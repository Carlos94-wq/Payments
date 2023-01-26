using Dapper;
using Payments.Core.Entities;
using Payments.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Infra.Repositories
{
    public class CatalogRespository : ICatalogRespository
    {

        private readonly DbContext context;

        public CatalogRespository(DbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SUPPLIER>> supplierCatalog()
        {
            using (var conn = this.context.createConnection())
            {
                var parametrer = new
                {
                    Accion = 1
                };

                var paymentCatalog = await conn.QueryAsync<SUPPLIER>("spCatalogs", parametrer, commandType: CommandType.StoredProcedure);
                return paymentCatalog.ToList();
            }
        }

        public async Task<IEnumerable<CURRENCY>> cuerrencyCatalog()
        {
            using (var conn = this.context.createConnection())
            {
                var parametrer = new
                {
                    Accion = 2
                };

                var currencyCatalog = await conn.QueryAsync<CURRENCY>("spCatalogs", parametrer, commandType: CommandType.StoredProcedure);
                return currencyCatalog.ToList();
            }
        }
    }
}
