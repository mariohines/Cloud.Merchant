using System.Data;
using System.Threading.Tasks;
using Cloud.Merchant.Persistence.Core;

namespace Cloud.Merchant.Persistence.Abstractions.Context
{
    public interface IDbContext
    {
        DbProvider Provider { get; }
        IDbConnection CreateConnection();
        Task<IDbTransaction> CreateTransactionAsync();
    }
}