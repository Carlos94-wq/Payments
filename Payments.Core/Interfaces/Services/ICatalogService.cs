using Payments.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Core.Interfaces.Repository
{
    public interface ICatalogService
    {
        Task<IEnumerable<CURRENCY>> cuerrencyCatalog();
        Task<IEnumerable<SUPPLIER>> supplierCatalog();
    }
}