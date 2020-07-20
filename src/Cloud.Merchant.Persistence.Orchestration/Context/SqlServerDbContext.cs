using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Abstractions.Context;
using Cloud.Merchant.Persistence.Abstractions.Settings;
using Cloud.Merchant.Persistence.Core;

namespace Cloud.Merchant.Persistence.Orchestration.Context
{
    public sealed class SqlServerDbContext : IDbContext
    {
        private readonly IDbSettings<SqlConnection> _dbSettings;
        private Lazy<DbConnection> CurrentConnection => new Lazy<DbConnection>(() => _dbSettings.CreateConnection());
        private Lazy<Task<DbTransaction>> CurrentTransaction => new Lazy<Task<DbTransaction>>(async () => await CurrentConnection.Value.BeginTransactionAsync(IsolationLevel.ReadCommitted));
        
        public DbProvider Provider => DbProvider.SqlServer;

        public SqlServerDbContext(IDbSettings<SqlConnection> dbSettings) {
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