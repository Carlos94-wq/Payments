using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.CustomEntities
{
    public class PaymentQueryFilters
    {
        public int? supplierId{ get; set; }
        public string email { get; set; }
        public int? paymentId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
