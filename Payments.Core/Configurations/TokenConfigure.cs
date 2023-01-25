using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.CustomEntities
{
    public class TokenConfigure
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public int accessExpiration { get; set; }
        public int refreshExpiration { get; set; }
    }
}
