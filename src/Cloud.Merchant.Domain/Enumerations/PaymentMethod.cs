using System;
using System.Linq;
using Cloud.Merchant.Domain.Base;

namespace Cloud.Merchant.Domain.Enumerations
{
    public sealed class PaymentMethod : Enumeration<short>
    {
        public static readonly PaymentMethod None = new PaymentMethod(0, nameof(None));
        public static readonly PaymentMethod GiftCard = new PaymentMethod(1, nameof(GiftCard));
        public static readonly PaymentMethod CreditCardToken = new PaymentMethod(2, nameof(CreditCardToken));
        public static readonly PaymentMethod CreditCard = new PaymentMethod(3, nameof(CreditCard));
        public static readonly PaymentMethod SavedCreditCard = new PaymentMethod(4, nameof(SavedCreditCard));
        public static readonly PaymentMethod ApplePay = new PaymentMethod(5, nameof(ApplePay));
        public static readonly PaymentMethod GooglePay = new PaymentMethod(6, nameof(GooglePay));
        
        private PaymentMethod(short id, string name) : base(id, name)
        {
        }

        public static implicit operator short(PaymentMethod paymentMethod)
        {
            return paymentMethod.Id;
        }

        public static implicit operator PaymentMethod(short value)
        {
            return GetAll<PaymentMethod>().SingleOrDefault(s => s.Id == value)
                   ?? None;
        }

        public static implicit operator string(PaymentMethod paymentMethod)
        {
            return paymentMethod.Name;
        }

        public static implicit operator PaymentMethod(string value)
        {
            return GetAll<PaymentMethod>().SingleOrDefault(s => s.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                   ?? None;
        }
    }
}