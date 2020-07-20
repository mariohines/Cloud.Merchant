using System;
using System.Collections.Generic;

namespace Cloud.Merchant.Business.Abstractions.Models
{
    public sealed class PaymentGatewayDto
    {
        public string Type { get; set; }
        public IDictionary<string, string> ConfigurationInformation { get; set; }
        public ICollection<string> AllowedPaymentMethods { get; set; }
    }
}