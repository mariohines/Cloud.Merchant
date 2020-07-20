using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Commands
{
    public readonly struct UpdateMerchantEntityCommand : IRequest<MerchantEntity>
    {
        public MerchantEntity Data { get; }

        public UpdateMerchantEntityCommand(MerchantEntity data) {
            Data = data;
        }
    }
}