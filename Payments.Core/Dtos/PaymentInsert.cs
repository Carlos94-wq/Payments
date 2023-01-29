using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Dtos
{
    public class PaymentInsert
    {
        public int SupplierId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public string Comments { get; set; }

        public bool PaymentStatus { get; set; }
    }
}
