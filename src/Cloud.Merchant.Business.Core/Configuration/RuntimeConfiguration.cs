namespace Cloud.Merchant.Business.Core.Configuration
{
    public sealed class RuntimeConfiguration
    {
        public DbProvider DbConnectionProvider { get; set; }
        public string DbConnectionString { get; set; }
    }
}