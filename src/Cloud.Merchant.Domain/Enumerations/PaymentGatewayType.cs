using System;
using System.Linq;
using Cloud.Merchant.Domain.Base;

namespace Cloud.Merchant.Domain.Enumerations
{
    public sealed class PaymentGatewayType : Enumeration<short>
    {
        public static readonly PaymentGatewayType None = new PaymentGatewayType(0, nameof(None));
        public static readonly PaymentGatewayType BlueSnap = new PaymentGatewayType(1, nameof(BlueSnap));
        public static readonly PaymentGatewayType MonetaryPay = new PaymentGatewayType(2, nameof(MonetaryPay));
        public static readonly PaymentGatewayType MockGatewayType = new PaymentGatewayType(3, nameof(MockGatewayType));
        public static readonly PaymentGatewayType Heartland = new PaymentGatewayType(4, nameof(Heartland));
        public static readonly PaymentGatewayType Payeezy = new PaymentGatewayType(5, nameof(Payeezy));
        
        private PaymentGatewayType(short id, string name) : base(id, name)
        {
        }

        public static implicit operator short(PaymentGatewayType paymentGatewayType)
        {
            return paymentGatewayType.Id;
        }

        public static implicit operator string(PaymentGatewayType paymentGatewayType)
        {
            return paymentGatewayType.Name;
        }

        public static implicit operator PaymentGatewayType(short value)
        {
            return GetAll<PaymentGatewayType>().SingleOrDefault(s => s.Id == value)
                   ?? None;
        }

        public static implicit operator PaymentGatewayType(string value)
        {
            return GetAll<PaymentGatewayType>().SingleOrDefault(s => s.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                   ?? None;
        }
    }
}