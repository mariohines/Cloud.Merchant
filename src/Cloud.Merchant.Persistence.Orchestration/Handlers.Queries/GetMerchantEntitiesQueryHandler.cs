using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Abstractions.Queries;
using Cloud.Merchant.Persistence.Core.Entities;
using Cloud.Merchant.Persistence.Orchestration.Extensions;
using Dapper;
using MediatR;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Queries
{
    public sealed class GetMerchantEntitiesQueryHandler : IRequestHandler<GetMerchantEntitiesQuery, IEnumerable<MerchantEntity>>
    {
        private readonly IDbContext _dbContext;
        private const string GetMerchantEntitiesSql = "select Id, PublicId, Name, Description, IsActive from merchant;";

        public GetMerchantEntitiesQueryHandler(IDbContext dbContext) {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<MerchantEntity>> Handle(GetMerchantEntitiesQuery request, CancellationToken cancellationToken) {
            var query = DbQuery.Create(GetMerchantEntitiesSql, token: cancellationToken);
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<MerchantEntity>(query.BuildCommandDefinition());
        }
    }
}