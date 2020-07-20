using System;

namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public sealed class MerchantSettingEntityNotFoundException : Exception
    {
        public MerchantSettingEntityNotFoundException() : base(ExceptionMessages.Specific.MerchantSettingNotFound) {
            
        }
    }
}