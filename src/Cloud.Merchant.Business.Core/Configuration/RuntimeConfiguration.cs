namespace Cloud.Merchant.Business.Core.Configuration
{
    public sealed class RuntimeConfiguration
    {
        public DbProvider DatabaseProvider { get; set; }
        public string DatabaseConnectionString { get; set; }
    }
}