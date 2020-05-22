using System.Collections.Generic;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantPaymentGatewaysByMerchantIdQuery : IRequest<IEnumerable<MerchantPaymentGatewayEntity>>
    {
        public long Key { get; }

        public GetMerchantPaymentGatewaysByMerchantIdQuery(long key) {
            Key = key;
        }
    }
}