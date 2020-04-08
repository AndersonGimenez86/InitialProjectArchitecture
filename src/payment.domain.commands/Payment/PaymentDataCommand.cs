namespace AG.PaymentApp.Domain.commands.Payments
{
    using AG.PaymentApp.Domain.events;

    public class PaymentDataCommand
    {
        public PaymentDataCommand(PaymentMongo payment)
        {
            this.PaymentMongo = payment;
        }

        public PaymentMongo PaymentMongo { get; }
    }
}