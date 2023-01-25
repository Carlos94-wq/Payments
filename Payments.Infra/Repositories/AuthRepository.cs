using Dapper;
using Payments.Core.Entities;
using Payments.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Infra.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DbContext _dbContext;

        public AuthRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<USER> login(USER user)
        {
            using (var conn = this._dbContext.createConnection())
            {
                var parametrer = new
                {
                    Email = user.Email,
                    Password = user.Password
                };

                var loggedUser = await conn.QueryAsync<USER>("spAuth", parametrer, commandType: System.Data.CommandType.StoredProcedure);
                return loggedUser.FirstOrDefault();
            }
        }
    }
}
