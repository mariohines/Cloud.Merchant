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
    public sealed class
        GetMerchantPaymentGatewayEntitiesByMerchantIdQueryHandler : IRequestHandler<GetMerchantPaymentGatewayEntitiesByMerchantIdQuery, IEnumerable<MerchantPaymentGatewayEntity>>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<GetMerchantPaymentGatewayEntitiesByMerchantIdQueryHandler> _logger;
        private const string GetMerchantPaymentGatewayEntitiesByMerchantIdSql =
            @"select MerchantId, PaymentGatewayId, JsonApiConfiguration, JsonAllowedPaymentMethods 
            from merchant_payment_gateway as mpg 
            inner join payment_gateway as pg on mpg.PaymentGatewayId = pg.Id 
            where MerchantId = @Key;";

        public GetMerchantPaymentGatewayEntitiesByMerchantIdQueryHandler(IDbContext dbContext, ILogger<GetMerchantPaymentGatewayEntitiesByMerchantIdQueryHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<MerchantPaymentGatewayEntity>> Handle(GetMerchantPaymentGatewayEntitiesByMerchantIdQuery request, CancellationToken cancellationToken) {
            try {
                var query = DbQuery.Create(GetMerchantPaymentGatewayEntitiesByMerchantIdSql, request, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                var result = await connection.QueryAsync<MerchantPaymentGatewayEntity>(query.BuildCommandDefinition());
                return result;
            }
            catch (Exception e) {
                _logger.LogError(e, "An unknown error has occurred.");
                throw;
            }
        }
    }
}