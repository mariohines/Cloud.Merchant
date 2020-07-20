using System;

namespace Cloud.Merchant.Persistence.Core.Exceptions
{
    public sealed class IncorrectEntityOperationException : Exception
    {
        public IncorrectEntityOperationException() : base(ExceptionMessages.Specific.IncorrectOperation) {
            
        }
    }
}