using Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task<USER> login(USER user);
    }
}
