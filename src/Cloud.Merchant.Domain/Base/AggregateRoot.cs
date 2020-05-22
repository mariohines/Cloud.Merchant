using System;

namespace Cloud.Merchant.Domain.Base
{
    public abstract class AggregateRoot<TType>
    {
        internal TType Id { get; }
        public Guid PublicId { get; }

        protected AggregateRoot(TType id, Guid publicId) {
            Id = id;
            PublicId = publicId;
        }
    }
}