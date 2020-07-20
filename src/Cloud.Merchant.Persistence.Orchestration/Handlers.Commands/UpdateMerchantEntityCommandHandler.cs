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
    public sealed class UpdateMerchantEntityCommandHandler : IRequestHandler<UpdateMerchantEntityCommand, MerchantEntity>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<UpdateMerchantEntityCommandHandler> _logger;

        public UpdateMerchantEntityCommandHandler(IDbContext dbContext, ILogger<UpdateMerchantEntityCommandHandler> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<MerchantEntity> Handle(UpdateMerchantEntityCommand request, CancellationToken cancellationToken) {
            try {
                if (request.Data.Id <= 0) throw new IncorrectEntityOperationException();
                var sql = $@"update merchant set Name = @Name, Description = @Description, IsActive = @IsActive, ModifyDate = {_dbContext.Provider.GetUtcDateSyntax()} 
                                where Id = @Id;";
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