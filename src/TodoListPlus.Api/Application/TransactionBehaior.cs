using Fx.SeedWork.EventBus.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoListPlus.Infrastructure;

namespace TodoListPlus.Api.Application
{
    public class TransactionBehaior<TRequest, TRespose>
        : IPipelineBehavior<TRequest, TRespose> where TRequest : IRequest<TRespose>
    {
        private readonly ILogger<TransactionBehaior<TRequest, TRespose>> _logger;
        private readonly TodoListPlusDbContext _dbContext;

        public TransactionBehaior(ILogger<TransactionBehaior<TRequest, TRespose>> logger, TodoListPlusDbContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TRespose> Handle(TRequest request, RequestHandlerDelegate<TRespose> next, CancellationToken cancellationToken)
        {
            var response = default(TRespose);
            var typeName = request.GetGenericTypeName();

            try
            {
                if (_dbContext.HasActiveTransaction)
                {
                    return await next();
                }

                var strategy = _dbContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    await using var transaction = await _dbContext.BeginTransactionAsync();
                    using (_logger.BeginScope(new List<KeyValuePair<string, object>> { new("TransactionContext", transaction.TransactionId) }))
                    {
                        _logger.LogInformation("Begin transaction {TransactionId} for {CommandName} ({@command})", transaction.TransactionId, typeName, request);

                        response = await next();

                        _logger.LogInformation("Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                        await _dbContext.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }
                   
                });

                return response;
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error Handling transaction for {CommandName} ({@Command})", typeName, request);

                throw;
            }
        }
    }
}
