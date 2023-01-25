using Microsoft.Extensions.Options;
using Payments.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Payments.Infra
{
    public class DbContext
    {
        private readonly ConnectionStrings options;

        public DbContext(IOptions<ConnectionStrings> options)
        {
            this.options = options.Value;
        }

        public IDbConnection createConnection()
        {
            return new SqlConnection(this.options.dbPayments);
        }
    }
}
