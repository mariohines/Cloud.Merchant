using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct UpdateMerchantSettingCommand : IRequest<MerchantSettingDto>
    {
        public MerchantSettingDto Model { get; }

        public UpdateMerchantSettingCommand(MerchantSettingDto model) {
            Model = model;
        }
    }
}