using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Abstractions.Settings;
using MySql.Data.MySqlClient;

namespace Cloud.Merchant.Persistence.Orchestration.Context
{
    public sealed class MySqlDbContext : IDbContext
    {
        private readonly IDbSettings<MySqlConnection> _dbSettings;
        private Lazy<DbConnection> CurrentConnection => new Lazy<DbConnection>(() => _dbSettings.CreateConnection());
        private Lazy<Task<IDbTransaction>> CurrentTransaction => new Lazy<Task<IDbTransaction>>(async () => await CurrentConnection.Value.BeginTransactionAsync(IsolationLevel.ReadCommitted));

        public MySqlDbContext(IDbSettings<MySqlConnection> dbSettings) {
            _dbSettings = dbSettings;
        }
        
        public IDbConnection CreateConnection() {
            return CurrentConnection.Value;
        }

        public async Task<IDbTransaction> CreateTransactionAsync() {
            return await CurrentTransaction.Value;
        }
    }
}