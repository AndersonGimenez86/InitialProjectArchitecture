namespace AG.PaymentApp.Domain.Commands.Payments
{
    using System;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using Payment.Domain.Core.Commands;

    public abstract class PaymentCommand : Command
    {
        public Guid ShopperID { get; set; }

        public Guid MerchantID { get; set; }

        public Guid TransactionID { get; set; }

        public Money Amount { get; set; }

        public PaymentStatus Status { get; set; }
    }
}