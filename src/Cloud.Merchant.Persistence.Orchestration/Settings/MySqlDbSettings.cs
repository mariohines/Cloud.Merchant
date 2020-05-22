using Cloud.Merchant.Persistence.Abstractions.Settings;
using MySql.Data.MySqlClient;

namespace Cloud.Merchant.Persistence.Orchestration.Settings
{
    public sealed class MySqlDbSettings : IDbSettings<MySqlConnection>
    {
        private readonly string _connectionString;

        public MySqlDbSettings(string connectionString) {
            _connectionString = connectionString;
        }
        
        public MySqlConnection CreateConnection() {
            return new MySqlConnection(_connectionString);
        }
    }
}