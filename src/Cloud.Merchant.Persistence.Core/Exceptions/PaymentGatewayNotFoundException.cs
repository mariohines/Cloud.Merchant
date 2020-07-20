using System;

namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public sealed class PaymentGatewayNotFoundException : Exception
    {
        public PaymentGatewayNotFoundException() : base(ExceptionMessages.Specific.PaymentGatewayNotFound) {
            
        }
    }
}