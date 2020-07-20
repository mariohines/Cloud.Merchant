using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Abstractions.Settings;
using Cloud.Merchant.Persistence.Core;
using MySql.Data.MySqlClient;

namespace Cloud.Merchant.Persistence.Orchestration.Context
{
    public sealed class MySqlDbContext : IDbContext
    {
        private readonly IDbSettings<MySqlConnection> _dbSettings;
        private Lazy<DbConnection> CurrentConnection => new Lazy<DbConnection>(() => _dbSettings.CreateConnection());
        private Lazy<Task<DbTransaction>> CurrentTransaction => new Lazy<Task<DbTransaction>>(async () => await CurrentConnection.Value.BeginTransactionAsync(IsolationLevel.ReadCommitted));

        public DbProvider Provider => DbProvider.MySql;

        public MySqlDbContext(IDbSettings<MySqlConnection> dbSettings) {
            _dbSettings = dbSettings;
        }
        
        public IDbConnection CreateConnection() {
            return CurrentConnection.Value;
        }

        public async Task<DbTransaction> CreateTransactionAsync() {
            return await CurrentTransaction.Value;
        }
    }
}