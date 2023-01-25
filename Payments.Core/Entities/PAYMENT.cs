using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Entities
{
    public class PAYMENT
    {
        public int PaymentId { get; set; }

        public int SupplierId { get; set; }

        public int UserId { get; set; }

        public decimal? Amount { get; set; }

        public int? CurrencyId { get; set; }

        public string Comments { get; set; }

        public bool PaymentStatus { get; set; }

        public DateTime? RecordingDate { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public DateTime? DeleteingDate { get; set; }

    }
}
