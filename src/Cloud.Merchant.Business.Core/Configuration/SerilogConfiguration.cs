namespace Cloud.Merchant.Business.Core.Configuration
{
    public sealed class SerilogConfiguration
    {
        public string SeqEndpoint { get; set; }
        public int MaxFileRetention { get; set; }
    }
}