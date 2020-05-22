using System.Collections.Generic;
using Cloud.Merchant.Persistence.Core.Entities;
using MediatR;

namespace Cloud.Merchant.Persistence.Abstractions.Queries
{
    public readonly struct GetMerchantEntitiesQuery : IRequest<IEnumerable<MerchantEntity>>
    {
        
    }
}