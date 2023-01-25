using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Dtos
{
    public class PaymentUpdate: PaymentInsert
    {
        public int PaymentId { get; set; }
    }
}
