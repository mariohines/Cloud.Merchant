using System;
using System.Collections.Generic;

namespace Cloud.Merchant.Business.Abstractions.Models
{
    public sealed class MerchantSettingDto
    {
        public Guid MerchantId { get; set; }
        public string MastheadBackgroundColor { get; set; }
        public IDictionary<string, string> CommunicationInformation { get; set; }
        public IDictionary<string,string> CustomUrls { get; set; }
    }
}