using Payments.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Infra.Repositories
{
    public interface ICatalogRespository
    {
        Task<IEnumerable<CURRENCY>> cuerrencyCatalog();
        Task<IEnumerable<SUPPLIER>> supplierCatalog();
    }
}