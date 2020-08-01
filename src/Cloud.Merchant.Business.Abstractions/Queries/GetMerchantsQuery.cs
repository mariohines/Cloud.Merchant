using System.Collections.Generic;
using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Queries
{
    public readonly struct GetMerchantsQuery : IRequest<ICollection<MerchantDto>>
    {
        
    }
}