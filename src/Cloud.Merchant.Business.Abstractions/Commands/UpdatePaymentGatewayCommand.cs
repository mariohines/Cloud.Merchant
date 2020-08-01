using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct UpdatePaymentGatewayCommand : IRequest<PaymentGatewayDto>
    {
        public PaymentGatewayDto Model { get; }

        public UpdatePaymentGatewayCommand(PaymentGatewayDto model) {
            Model = model;
        }
    }
}