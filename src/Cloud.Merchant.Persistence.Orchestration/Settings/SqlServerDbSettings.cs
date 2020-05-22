using System.Data.SqlClient;
using Cloud.Merchant.Persistence.Abstractions.Settings;

namespace Cloud.Merchant.Persistence.Orchestration.Settings
{
    public sealed class SqlServerDbSettings : IDbSettings<SqlConnection>
    {
        private readonly string _connectionString;

        public SqlServerDbSettings(string connectionString) {
            _connectionString = connectionString;
        }
        
        public SqlConnection CreateConnection() {
            return new SqlConnection(_connectionString);
        }
    }
}