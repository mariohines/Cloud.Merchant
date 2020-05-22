using System;

namespace Cloud.Merchant.Persistence.Core.Entities
{
    public sealed class MerchantEntity
    {
        public long Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}