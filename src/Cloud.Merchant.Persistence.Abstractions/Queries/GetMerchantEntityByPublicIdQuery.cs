using System;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantEntityByPublicIdQuery : IRequest<MerchantEntity>
    {
        public Guid Key { get; }

        public GetMerchantEntityByPublicIdQuery(Guid key) {
            Key = key;
        }
    }
}