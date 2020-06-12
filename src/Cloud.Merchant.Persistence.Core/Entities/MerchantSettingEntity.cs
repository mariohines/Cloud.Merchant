namespace Cloud.Merchant.Persistence.Core.Entities
{
    public sealed class MerchantSettingEntity
    {
        public long MerchantId { get; set; }
        public string BaseUrl { get; set; }
        public string BaseImageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string MastheadBackgroundUrl { get; set; }
        public string MastheadBackgroundColor { get; set; }
        public string MenuImageBaseUrl { get; set; }
        public string JsonCommunicationConfiguration { get; set; }
    }
}