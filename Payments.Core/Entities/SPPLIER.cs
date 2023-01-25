using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Entities
{
    public class SUPPLIER
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public DateTime RecordingDate { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public DateTime? DeleteingDate { get; set; }

    }
}
