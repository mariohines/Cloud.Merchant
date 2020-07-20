using System;

namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public sealed class MerchantEntityNotFoundException : Exception
    {
        public MerchantEntityNotFoundException() : base(ExceptionMessages.Specific.MerchantNotFound) {
            
        }
    }
}