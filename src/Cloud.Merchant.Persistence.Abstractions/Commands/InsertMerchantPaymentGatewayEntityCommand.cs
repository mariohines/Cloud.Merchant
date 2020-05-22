using System;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct InsertMerchantPaymentGatewayEntityCommand : IRequest<(Guid, int)>
    {
        public MerchantPaymentGatewayEntity Data { get; }

        public InsertMerchantPaymentGatewayEntityCommand(MerchantPaymentGatewayEntity data) {
            Data = data;
        }
    }
}