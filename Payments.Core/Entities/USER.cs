using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Entities
{
    public class USER
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RecordingDate { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public DateTime? DeleteingDate { get; set; }

    }
}
