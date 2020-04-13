namespace AG.PaymentApp.Domain.Commands.Payments
{
    using AG.PaymentApp.Domain.events;

    public class PaymentCommand
    {
        public PaymentCommand(PaymentMongo payment)
        {
            this.PaymentMongo = payment;
        }

        public override Guid PaymentID { get; set; }

        public override Guid ShopperID { get; set; }

        public override Guid MerchantID { get; set; }

        public Guid TransactionID { get; set; }

        public Money Amount { get; set; }

        public CreditCardProtected CreditCard { get; set; }

        public string Reference { get; set; }

        public PaymentStatus Status { get; set; }
    }
}