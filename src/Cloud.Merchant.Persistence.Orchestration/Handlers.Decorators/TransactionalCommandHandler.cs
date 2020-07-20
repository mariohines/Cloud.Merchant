using System;
using System.Threading;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions.Context;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloud.Merchant.Persistence.Orchestration.Handlers.Decorators
{
    public sealed class TransactionalCommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
    {
        private readonly IRequestHandler<IRequest<TResponse>, TResponse> _requestHandler;
        private readonly IDbContext _dbContext;
        private readonly ILogger<TransactionalCommandHandler<TCommand, TResponse>> _logger;

        public TransactionalCommandHandler(IRequestHandler<IRequest<TResponse>, TResponse> requestHandler, IDbContext dbContext, ILogger<TransactionalCommandHandler<TCommand, TResponse>> logger) {
            _requestHandler = requestHandler;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken) {
            TResponse result;
            await using var transaction = await _dbContext.CreateTransactionAsync();
            try {
                result = await _requestHandler.Handle(request, cancellationToken);
            }
            catch (Exception e) {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
            
            await transaction.CommitAsync(cancellationToken);
            return result;
        }
    }
}