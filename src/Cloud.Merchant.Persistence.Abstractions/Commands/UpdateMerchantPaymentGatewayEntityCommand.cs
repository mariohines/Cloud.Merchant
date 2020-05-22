using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct UpdateMerchantPaymentGatewayEntityCommand : IRequest<MerchantPaymentGatewayEntity>
    {
        public MerchantPaymentGatewayEntity Data { get; }

        public UpdateMerchantPaymentGatewayEntityCommand(MerchantPaymentGatewayEntity data) {
            Data = data;
        }
    }
}