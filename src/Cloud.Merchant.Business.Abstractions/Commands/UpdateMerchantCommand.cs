using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct UpdateMerchantCommand : IRequest<MerchantDto>
    {
        public MerchantDto Model { get; }

        public UpdateMerchantCommand(MerchantDto model) {
            Model = model;
        }
    }
}