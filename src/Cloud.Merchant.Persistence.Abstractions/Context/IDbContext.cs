using System.Data;
using System.Threading.Tasks;

namespace Cloud.Merchant.Persistence.Abstractions.Context
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
        Task<IDbTransaction> CreateTransactionAsync();
    }
}