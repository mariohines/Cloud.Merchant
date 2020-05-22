using System.Collections.Generic;
using Cloud.Merchant.Domain.Enumerations;

namespace Cloud.Merchant.Domain.Models
{
    public sealed class PaymentGateway
    {
        public PaymentGatewayType Type { get; }
        public string ApiConfiguration { get; }
        public ICollection<PaymentMethod> PaymentMethodSet { get; }

        public PaymentGateway(PaymentGatewayType type, string apiConfiguration, IEnumerable<PaymentMethod> paymentMethods) {
            Type = type;
            ApiConfiguration = apiConfiguration;
            PaymentMethodSet = new List<PaymentMethod>(paymentMethods);
        }
    }
}