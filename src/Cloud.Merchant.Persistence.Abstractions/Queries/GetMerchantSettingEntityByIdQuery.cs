using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantSettingEntityByIdQuery : IRequest<MerchantSettingEntity>
    {
        public long Key { get; }

        public GetMerchantSettingEntityByIdQuery(long key) {
            Key = key;
        }
    }
}