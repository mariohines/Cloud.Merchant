using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct InsertPaymentGatewayCommand : IRequest<PaymentGatewayDto>
    {
        public PaymentGatewayDto Model { get; }

        public InsertPaymentGatewayCommand(PaymentGatewayDto model) {
            Model = model;
        }
    }
}