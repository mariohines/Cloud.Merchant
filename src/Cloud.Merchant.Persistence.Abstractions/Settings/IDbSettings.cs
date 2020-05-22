using System.Data;

namespace Cloud.Merchant.Persistence.Abstractions.Settings
{
    public interface IDbSettings<out TConnection> where TConnection : IDbConnection
    {
        TConnection CreateConnection();
    }
}