using System;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct InsertMerchantEntityCommand : IRequest<Guid>
    {
        public MerchantEntity Data { get; }

        public InsertMerchantEntityCommand(MerchantEntity data) {
            Data = data;
        }
    }
}