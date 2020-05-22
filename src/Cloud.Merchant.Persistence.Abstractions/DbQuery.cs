using System.Data;
using System.Threading;

namespace Cloud.Merchant.Persistence.Abstractions
{
    public sealed class DbQuery
    {
        public string Sql { get; }
        public object Parameters { get; }
        public CommandType CommandType { get; }
        public CancellationToken Token { get; }

        private DbQuery(string sql, object parameters = null, CommandType commandType = CommandType.Text, CancellationToken token = default) {
            Sql = sql;
            Parameters = parameters;
            CommandType = commandType;
            Token = token;
        }

        public static DbQuery Create(string sql, object parameters = null, CommandType commandType = CommandType.Text, CancellationToken token = default) {
            return new DbQuery(sql, parameters, commandType, token);
        }
    }
}