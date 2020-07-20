using System;
using System.Threading;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions;
using Cloud.Merchant.Persistence.Abstractions.Commands;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Core.Entities;
using Cloud.Merchant.Persistence.Core.Exceptions;
using Cloud.Merchant.Persistence.Orchestration.Extensions;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Commands
{
    public sealed class UpdateMerchantPaymentGatewayEntityCommandHandler : IRequestHandler<UpdateMerchantPaymentGatewayEntityCommand, MerchantPaymentGatewayEntity>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<UpdateMerchantPaymentGatewayEntityCommandHandler> _logger;

        public UpdateMerchantPaymentGatewayEntityCommandHandler(IDbContext dbContext, ILogger<UpdateMerchantPaymentGatewayEntityCommandHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<MerchantPaymentGatewayEntity> Handle(UpdateMerchantPaymentGatewayEntityCommand request, CancellationToken cancellationToken) {
            try {
                if (request.Data.MerchantId == 0 || request.Data.PaymentGatewayId == 0) throw new IncorrectEntityOperationException();
                var sql =
                    $@"update merchant_payment_gateway set MerchantId = @MerchantId, PaymentGatewayId = @PaymentGatewayId, JsonApiConfiguration = @JsonApiConfiguration, ModifyDate = {_dbContext.Provider.GetUtcDateSyntax()}
                                where MerchantId = @MerchantId and PaymentGatewayId = @PaymentGatewayId;";
                var query = DbQuery.Create(sql, request.Data, token: cancellationToken);
                using var connection = _dbContext.CreateConnection();
                await connection.ExecuteAsync(query.BuildCommandDefinition());
                return request.Data;
            }
            catch (IncorrectEntityOperationException e) {
                _logger.LogError(e, ExceptionMessages.Standard.KnownError);
                throw;
            }
            catch (Exception e) {
                _logger.LogError(e, ExceptionMessages.Standard.UnknownError);
                throw;
            }
        }
    }
}