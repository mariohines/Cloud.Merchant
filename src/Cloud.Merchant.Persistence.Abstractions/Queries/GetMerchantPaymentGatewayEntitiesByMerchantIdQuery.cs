using System.Collections.Generic;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantPaymentGatewayEntitiesByMerchantIdQuery : IRequest<IEnumerable<MerchantPaymentGatewayEntity>>
    {
        public long Key { get; }

        public GetMerchantPaymentGatewayEntitiesByMerchantIdQuery(long key) {
            Key = key;
        }
    }
}