using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantEntityByIdQuery : IRequest<MerchantEntity>
    {
        public long Key { get; }

        public GetMerchantEntityByIdQuery(long key) {
            Key = key;
        }
    }
}