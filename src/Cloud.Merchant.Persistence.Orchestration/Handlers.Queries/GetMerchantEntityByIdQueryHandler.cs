using System.Threading;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Abstractions.Queries;
using Cloud.Merchant.Persistence.Core.Entities;
using Cloud.Merchant.Persistence.Core.Exceptions;
using Cloud.Merchant.Persistence.Orchestration.Extensions;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Queries
{
    public sealed class GetMerchantEntityByIdQueryHandler : IRequestHandler<GetMerchantEntityByIdQuery, MerchantEntity>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<GetMerchantEntityByIdQueryHandler> _logger;
        private const string GetMerchantEntityByIdSql = "select Id, PublicId, Name, Description, IsActive from merchant where Id = @Key;";

        public GetMerchantEntityByIdQueryHandler(IDbContext dbContext, ILogger<GetMerchantEntityByIdQueryHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<MerchantEntity> Handle(GetMerchantEntityByIdQuery request, CancellationToken cancellationToken) {
            var query = DbQuery.Create(GetMerchantEntityByIdSql, request, token: cancellationToken);
            using var connection = _dbContext.CreateConnection();
            var result = await connection.QuerySingleAsync<MerchantEntity>(query.BuildCommandDefinition());
            if (result != null) return result;
            var exception = new MerchantEntityNotFoundException();
            _logger.LogError(exception, $"Unable to find a merchant with Id of: '{request.Key}'.");
            throw exception;
        }
    }
}