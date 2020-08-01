using System;
using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct InsertMerchantSettingCommand : IRequest<Guid>
    {
        public MerchantSettingDto Model { get; }

        public InsertMerchantSettingCommand(MerchantSettingDto model) {
            Model = model;
        }
    }
}