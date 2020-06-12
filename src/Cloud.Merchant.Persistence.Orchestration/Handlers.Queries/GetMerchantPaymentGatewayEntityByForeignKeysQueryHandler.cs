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
    public sealed class GetMerchantPaymentGatewayEntityByForeignKeysQueryHandler : IRequestHandler<GetMerchantPaymentGatewayEntityByForeignKeysQuery, MerchantPaymentGatewayEntity>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<GetMerchantPaymentGatewayEntityByForeignKeysQueryHandler> _logger;
        private const string GetMerchantPaymentGatewayEntitiesByForeignKeysSql =
            @"select MerchantId, PaymentGatewayId, JsonApiConfiguration, JsonAllowedPaymentMethods 
            from merchant_payment_gateway as mpg 
            inner join payment_gateway as pg on mpg.PaymentGatewayId = pg.Id 
            where MerchantId = @MerchantId and PaymentGatewayId = @PaymentGatewayId;";

        public GetMerchantPaymentGatewayEntityByForeignKeysQueryHandler(IDbContext dbContext, ILogger<GetMerchantPaymentGatewayEntityByForeignKeysQueryHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<MerchantPaymentGatewayEntity> Handle(GetMerchantPaymentGatewayEntityByForeignKeysQuery request, CancellationToken cancellationToken) {
            try {
                var query = DbQuery.Create(GetMerchantPaymentGatewayEntitiesByForeignKeysSql, request.Key, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                var result = await connection.QuerySingleOrDefaultAsync<MerchantPaymentGatewayEntity>(query.BuildCommandDefinition());
                if (result != null) return result;
                throw new PaymentGatewayNotFoundException();
            }
            catch (PaymentGatewayNotFoundException e) {
                _logger.LogError(e, $"Unable to find a PaymentGateway with Id: {request.Key.PaymentGatewayId}.");
                throw;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}