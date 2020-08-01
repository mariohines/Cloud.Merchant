using System;
using Cloud.Merchant.Business.Abstractions.Models;
using MediatR;

namespace Cloud.Merchant.Business.Abstractions.Queries
{
    public readonly struct GetMerchantByIdQuery : IRequest<MerchantDto>
    {
        public Guid Id { get; }

        public GetMerchantByIdQuery(Guid id) {
            Id = id;
        }
    }
}