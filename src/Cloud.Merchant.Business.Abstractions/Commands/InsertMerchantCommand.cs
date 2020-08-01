using System;
using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Commands
{
    public readonly struct InsertMerchantCommand : IRequest<Guid>
    {
        public MerchantDto Model { get; }

        public InsertMerchantCommand(MerchantDto model) {
            Model = model;
        }
    }
}