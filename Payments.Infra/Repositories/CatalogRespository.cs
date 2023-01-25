using Dapper;
using Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Infra.Repositories
{
    public class CatalogRespository
    {

        private readonly DbContext context;

        public CatalogRespository(DbContext context)
        {
            this.context = context;
        }


        public async Task<int> insertPaymnat( PAYMENT payments )
        {
            using (var conn = this.context.createConnection() )
            {
                var parametrer = new
                {
                    Accion = 1
                };

                var isInserted = await conn.ExecuteScalarAsync("spPyments", parametrer, commandType: CommandType.StoredProcedure);
                return Convert.ToInt32(isInserted);
            }
        }
    }
}
