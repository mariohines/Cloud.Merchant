using System;
using System.Collections.Generic;
using Cloud.Merchant.Business.Core.Extensions;
using Cloud.Merchant.Domain.Base;
using Cloud.Merchant.Domain.Enumerations;

namespace Cloud.Merchant.Domain.Models
{
    public sealed class Merchant : AggregateRoot<long>
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsActive { get; }
        public MerchantSetting Settings { get; private set; }
        public HashSet<PaymentGateway> PaymentGatewaySet { get; private set; }

        public Merchant(long id, Guid publicId, string name, string description = default, bool isActive = true) : base(id, publicId) {
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public void CreateSettings(MerchantSetting setting) {
            Settings = setting;
        }

        public void AddPaymentGateway(PaymentGateway gateway) {
            if (PaymentGatewaySet == null) {
                PaymentGatewaySet = new HashSet<PaymentGateway> {gateway};
            }
            else {
                PaymentGatewaySet.Add(gateway);
            }
        }
    }
}