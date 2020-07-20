using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Core;

namespace Cloud.Merchant.Persistence.Abstractions.Context
{
    public interface IDbContext
    {
        DbProvider Provider { get; }
        IDbConnection CreateConnection();
        Task<DbTransaction> CreateTransactionAsync();
    }
}