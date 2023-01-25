using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Core.Interfaces.Repository
{
    public interface IPaymentRepository
    {
        Task<int> insertPaymnat(PAYMENT payments);
        Task<int> updatePaymnat(PAYMENT payments);
        Task<int> deletedPaymnat(int paymentId);
        Task<PAYMENT> getPaymnatById(int paymentId);
        Task<IEnumerable<PaymentViewModel>> getAllPaymnat(PaymentQueryFilters filters);
    }
}