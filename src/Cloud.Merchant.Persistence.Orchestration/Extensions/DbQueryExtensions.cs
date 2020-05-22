using Cloud.Merchant.Persistence.Abstractions;
using Dapper;

namespace Cloud.Merchant.Persistence.Orchestration.Extensions
{
    public static class DbQueryExtensions
    {
        public static CommandDefinition BuildCommandDefinition(this DbQuery source) {
            return new CommandDefinition(source.Sql, source.Parameters, commandType: source.CommandType, cancellationToken: source.Token);
        }
    }
}