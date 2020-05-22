using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public struct GetMerchantSettingByMerchantIdQuery : IRequest<MerchantSettingEntity>
    {
        public long Key { get; }

        public GetMerchantSettingByMerchantIdQuery(long key) {
            Key = key;
        }
    }
}