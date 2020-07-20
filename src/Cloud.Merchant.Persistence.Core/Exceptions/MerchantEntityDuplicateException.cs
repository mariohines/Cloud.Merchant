using System;

namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public sealed class MerchantEntityDuplicateException : Exception
    {
        public MerchantEntityDuplicateException() : base(ExceptionMessages.Specific.MerchantDuplicate) {
            
        }
    }
}