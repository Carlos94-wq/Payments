using Microsoft.Extensions.Options;
using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using Payments.Core.Error;
using Payments.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly PaginationOptions _paginationOptions;

        public PaymentService(IPaymentRepository paymentRepository, IOptions<PaginationOptions> options)
        {
            this._paymentRepository = paymentRepository;
            this._paginationOptions = options.Value;
        }

        public async Task<bool> deletedPaymnat(int paymentId)
        {

            var playmentFlag = await this.getPaymnatById(paymentId);
            var paymentDeleted = await this._paymentRepository.deletedPaymnat(paymentId);

            if (!playmentFlag.PaymentStatus)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Este recibo ya ha sido eliminado");
            }

            return paymentDeleted > 0;
        }

        public async Task<PagedList<PaymentViewModel>> getAllPayments(PaymentQueryFilters filters)
        {
            filters.pageNumber = filters.pageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.pageNumber;
            filters.pageSize = filters.pageSize == 0 ? _paginationOptions.DefaultPageSize : filters.pageSize;

            var Payments = await this._paymentRepository.getAllPaymnat(filters);

            if (Payments.Count() == 0)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Lo sentimos no encontramos resultados");
            }

            return PagedList<PaymentViewModel>.Create(Payments, filters.pageNumber, filters.pageSize);
        }

        public async Task<PAYMENT> getPaymnatById(int paymentId)
        {

            var payment = await this._paymentRepository.getPaymnatById(paymentId);
            if (payment == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "No se encontro ningun recibo");
            }

            return payment;
        }

        public async Task<int> insertPaymnat(PAYMENT payments)
        {
            var isInserted = await this._paymentRepository.insertPaymnat(payments);

            if (isInserted < 1)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No pudimos registrar tu recibo");
            }

            return isInserted;
        }

        public async Task<bool> updatePaymnat(PAYMENT payments)
        {
            var isInserted = await this._paymentRepository.updatePaymnat(payments);

            if (isInserted < 1)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "No pudimos registrar tu recibo");
            }

            return isInserted > 0;
        }
    }
}
