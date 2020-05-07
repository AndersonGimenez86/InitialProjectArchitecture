namespace AG.PaymentApp.Domain.Commands.Payments
{
    using System;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;

    public abstract class PaymentCommand : Command
    {
        public Guid ShopperID { get; set; }

        public Guid MerchantID { get; set; }

        public Guid TransactionID { get; set; }

        public Money Amount { get; set; }

        public PaymentStatus Status { get; set; }
    }
}