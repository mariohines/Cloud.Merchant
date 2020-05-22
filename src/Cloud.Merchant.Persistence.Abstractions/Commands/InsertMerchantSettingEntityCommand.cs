using System;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct InsertMerchantSettingEntityCommand : IRequest<Guid>
    {
        public MerchantSettingEntity Data { get; }

        public InsertMerchantSettingEntityCommand(MerchantSettingEntity data) {
            Data = data;
        }
    }
}