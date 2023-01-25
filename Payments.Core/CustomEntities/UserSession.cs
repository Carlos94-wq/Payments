using Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.CustomEntities
{
    public class UserSession
    {
        public USER usuario { get; set; }
        public string token { get; set; }
    }
}
