using System;
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
    public sealed class GetMerchantSettingEntityByIdQueryHandler : IRequestHandler<GetMerchantSettingEntityByIdQuery, MerchantSettingEntity>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<GetMerchantSettingEntityByIdQueryHandler> _logger;
        private const string GetMerchantSettingEntityByIdSql =
            @"select MerchantId, BaseUrl, BaseImageUrl, LogoUrl, MastheadBackgroundUrl, MastheadBackgroundColor, MenuImageBaseUrl, JsonCommunicationConfiguration 
            from merchant_setting where MerchantId = @Key;";

        public GetMerchantSettingEntityByIdQueryHandler(IDbContext dbContext, ILogger<GetMerchantSettingEntityByIdQueryHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<MerchantSettingEntity> Handle(GetMerchantSettingEntityByIdQuery request, CancellationToken cancellationToken) {
            try {
                var query = DbQuery.Create(GetMerchantSettingEntityByIdSql, request, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                var result = await connection.QuerySingleOrDefaultAsync<MerchantSettingEntity>(query.BuildCommandDefinition());
                if (result != null) return result;
                throw new MerchantSettingEntityNotFoundException();
            }
            catch (MerchantSettingEntityNotFoundException e) {
                _logger.LogError(e, $"Unable to find Merchant Settings with Id: {request.Key}");
                throw;
            }
            catch (Exception e) {
                _logger.LogError(e, "An unknown error has occurred.");
                throw;
            }
        }
    }
}