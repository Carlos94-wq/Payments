using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.CustomEntities
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public string SupplierName{ get; set; }
        public string Email{ get; set; }
        public string Amount{ get; set; }
    }
}
