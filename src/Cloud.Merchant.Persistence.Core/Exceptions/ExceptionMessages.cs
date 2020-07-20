namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public static class ExceptionMessages
    {
        public static class Standard
        {
            public const string UnknownError = @"An unknown error has occurred. Please review the logs to understand what happened.";
            public const string KnownError = @"A known error has occurred. Please review the logs to understand what happened.";
        }

        public static class Specific
        {
            public const string IncorrectOperation = @"An incorrect request has been made based on the data provided.";
            public const string MerchantDuplicate = @"This merchant is not unique and already exists in the system.";
            public const string MerchantNotFound = @"Unable to locate an entry for the merchant with the specified information.";
            public const string MerchantSettingNotFound = @"Unable to locate an entry for the merchant setting with the specified information.";
            public const string PaymentGatewayNotFound = @"Unable to locate an entry for the payment gateway with the specified information.";
        }
    }
}