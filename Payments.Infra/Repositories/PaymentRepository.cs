using Dapper;
using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using Payments.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DbContext context;

        public PaymentRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> deletedPaymnat(int paymentId)
        {
            using (var conn = this.context.createConnection())
            {
                var parameters = new
                {
                    Accion = 4,
                    PaymentId = paymentId
                };

                var isDeleted = await conn.ExecuteAsync("spPayments", parameters, commandType: CommandType.StoredProcedure);
                return isDeleted;
            }
        }

        public async Task<IEnumerable<PaymentViewModel>> getAllPaymnat(PaymentQueryFilters filters)
        {
            using (var conn = this.context.createConnection())
            {
                var parameters = new
                {
                    Accion = 1,
                    SupplierId = filters.supplierId,
                    PaymentId = filters.paymentId,
                    Email = filters.email
                };

                var payments = await conn.QueryAsync<PaymentViewModel>("spPayments", parameters, commandType: CommandType.StoredProcedure);
                return payments;
            }
        }

        public async Task<PAYMENT> getPaymnatById(int paymentId)
        {
            using (var conn =  this.context.createConnection())
            {
                var parameters = new
                {
                    Accion = 5,
                    PaymentId = paymentId
                };

                var payments = await conn.QueryAsync<PAYMENT>("spPayments", parameters, commandType: CommandType.StoredProcedure);
                return payments.FirstOrDefault();
            }
        }

        public async Task<int> insertPaymnat(PAYMENT payments)
        {
            using (var conn = this.context.createConnection())
            {
                var parametrer = new
                {
                    Accion = 2,
                    SupplierId = payments.SupplierId,
                    UserId = payments.UserId,
                    Amount = payments.Amount,
                    CurrencyId = payments.CurrencyId,
                    Comments = payments.Comments
                };

                var isInserted = await conn.ExecuteScalarAsync("spPayments", parametrer, commandType: CommandType.StoredProcedure);
                return Convert.ToInt32(isInserted);
            }
        }

        public async Task<int> updatePaymnat(PAYMENT payments)
        {
            using (var conn = this.context.createConnection())
            {
                var parametrer = new
                {
                    Accion = 3,
                    PaymentId = payments.PaymentId,
                    SupplierId = payments.SupplierId,
                    UserId = payments.UserId,
                    Amount = payments.Amount,
                    CurrencyId = payments.CurrencyId,
                    Comments = payments.Comments,
                    PaymentStatus = payments.PaymentStatus,
                    RecordingDate = payments.RecordingDate,
                    UpdatingDate = payments.UpdatingDate,
                    DeleteingDate = payments.DeleteingDate
                };

                var isUpdated = await conn.ExecuteScalarAsync("spPayments", parametrer, commandType: CommandType.StoredProcedure);
                return Convert.ToInt32(isUpdated);
            }
        }
    }
}
