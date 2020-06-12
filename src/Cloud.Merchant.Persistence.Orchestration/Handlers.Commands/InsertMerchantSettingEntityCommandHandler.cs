using System;
using System.Threading;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions;
using Cloud.Merchant.Persistence.Abstractions.Commands;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Orchestration.Extensions;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Commands
{
    public sealed class InsertMerchantSettingEntityCommandHandler : IRequestHandler<InsertMerchantSettingEntityCommand, Guid>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<InsertMerchantSettingEntityCommandHandler> _logger;

        public InsertMerchantSettingEntityCommandHandler(IDbContext dbContext, ILogger<InsertMerchantSettingEntityCommandHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<Guid> Handle(InsertMerchantSettingEntityCommand request, CancellationToken cancellationToken) {
            try {
                var sql = $@"insert into merchant_setting (MerchantId, BaseUrl, BaseImageUrl, LogoUrl, MastheadBackgroundUrl, MastheadBackgroundColor, MenuImageBaseUrl, JsonCommunicationConfiguration, CreateDate) 
                                    values (@MerchantId, @BaseUrl, @BaseImageUrl, @LogoUrl, @MastheadBackgroundUrl, @MastheadBackgroundColor, @MenuImageBaseUrl, @JsonCommunicationConfiguration, {_dbContext.Provider.GetUtcDateSyntax()});
                                    select PublicId from merchant where Id = @MerchantId;";
                var query = DbQuery.Create(sql, request.Data, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                return await connection.ExecuteScalarAsync<Guid>(query.BuildCommandDefinition());
            }
            catch (Exception e) {
                _logger.LogError(e, "An unknown error has occurred.");
                throw;
            }
        }
    }
}