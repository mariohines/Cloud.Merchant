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
    public sealed class InsertMerchantPaymentGatewayEntityCommandHandler : IRequestHandler<InsertMerchantPaymentGatewayEntityCommand, (Guid, int)>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<InsertMerchantPaymentGatewayEntityCommandHandler> _logger;

        public InsertMerchantPaymentGatewayEntityCommandHandler(IDbContext dbContext, ILogger<InsertMerchantPaymentGatewayEntityCommandHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<(Guid, int)> Handle(InsertMerchantPaymentGatewayEntityCommand request, CancellationToken cancellationToken) {
            try {
                var sql = $@"insert into merchant_payment_gateway (MerchantId, PaymentGatewayId, JsonApiConfiguration, CreateDate) 
                                    values (@MerchantId, @PaymentGatewayId, @JsonApiConfiguration, {_dbContext.Provider.GetUtcDateSyntax()});
                                    select PublicId from merchant where Id = @MerchantId;";
                var query = DbQuery.Create(sql, request.Data, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                var result = await connection.ExecuteScalarAsync<Guid>(query.BuildCommandDefinition());
                return (result, request.Data.PaymentGatewayId);
            }
            catch (Exception e) {
                _logger.LogError(e, "An unknown error has occurred.");
                throw;
            }
        }
    }
}