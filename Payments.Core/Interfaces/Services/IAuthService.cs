using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserSession> login(USER user);
    }
}
