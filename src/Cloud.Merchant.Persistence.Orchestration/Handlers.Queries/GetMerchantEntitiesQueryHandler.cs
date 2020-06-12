using System;
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
using Microsoft.Extensions.Logging;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Queries
{
    public sealed class GetMerchantEntitiesQueryHandler : IRequestHandler<GetMerchantEntitiesQuery, IEnumerable<MerchantEntity>>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<GetMerchantEntitiesQueryHandler> _logger;
        private const string GetMerchantEntitiesSql = "select Id, PublicId, Name, Description, IsActive from merchant;";

        public GetMerchantEntitiesQueryHandler(IDbContext dbContext, ILogger<GetMerchantEntitiesQueryHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<IEnumerable<MerchantEntity>> Handle(GetMerchantEntitiesQuery request, CancellationToken cancellationToken) {
            try {
                var query = DbQuery.Create(GetMerchantEntitiesSql, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                return await connection.QueryAsync<MerchantEntity>(query.BuildCommandDefinition());
            }
            catch (Exception e) {
                _logger.LogError(e, "An unknown error has occurred.");
                throw;
            }
        }
    }
}