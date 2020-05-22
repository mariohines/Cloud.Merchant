using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct UpdateMerchantSettingEntityCommand : IRequest<MerchantSettingEntity>
    {
        public MerchantSettingEntity Data { get; }

        public UpdateMerchantSettingEntityCommand(MerchantSettingEntity data) {
            Data = data;
        }
    }
}