namespace Cloud.Merchant.Persistence.Core.Entities
{
    public sealed class MerchantPaymentGatewayEntity
    {
        public long MerchantId { get; set; }
        public int PaymentGatewayId { get; set; }
        public string JsonApiConfiguration { get; set; }
        public string JsonAllowedPaymentMethods { get; set; }
    }
}