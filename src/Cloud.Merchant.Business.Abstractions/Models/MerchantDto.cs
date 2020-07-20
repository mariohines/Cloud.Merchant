using System;
using System.Collections.Generic;

namespace Cloud.Merchant.Business.Abstractions.Models
{
    public sealed class MerchantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public MerchantSettingDto Settings { get; set; }
        public ICollection<PaymentGatewayDto> PaymentGateways { get; set; }
    }
}