using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantPaymentGatewayEntityByForeignKeysQuery : IRequest<MerchantPaymentGatewayEntity>
    {
        public (long MerchantId, int PaymentGatewayId) Key { get; }

        public GetMerchantPaymentGatewayEntityByForeignKeysQuery((long, int) key) {
            Key = key;
        }
    }
}