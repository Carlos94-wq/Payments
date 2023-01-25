using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Core.Interfaces.Repository
{
    public interface IPaymentService
    {
        Task<int> insertPaymnat(PAYMENT payments);
        Task<bool> updatePaymnat(PAYMENT payments);
        Task<bool> deletedPaymnat(int paymentId);
        Task<PAYMENT> getPaymnatById(int paymentId);
        Task<PagedList<PaymentViewModel>> getAllPayments(PaymentQueryFilters filters);
    }
}