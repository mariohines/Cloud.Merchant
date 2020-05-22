namespace Cloud.Merchant.Domain.Models
{
    public sealed class MerchantSetting
    {
        public UrlSettings UrlSettings { get; }
        public string MastheadBackgroundColor { get; }
        public string CommunicationConfiguration { get; }

        public MerchantSetting(UrlSettings urlSettings = default, string mastheadBackgroundColor = default, string communicationConfiguration = default) {
            UrlSettings = urlSettings;
            MastheadBackgroundColor = mastheadBackgroundColor;
            CommunicationConfiguration = communicationConfiguration;
        }
    }
}