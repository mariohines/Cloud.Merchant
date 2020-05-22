using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantPaymentGatewayByMerchantIdAndPaymentGatewayIdQuery : IRequest<MerchantPaymentGatewayEntity>
    {
        public (long MerchantId, int PaymentGatewayId) Key { get; }

        public GetMerchantPaymentGatewayByMerchantIdAndPaymentGatewayIdQuery((long, int) key) {
            Key = key;
        }
    }
}