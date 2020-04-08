namespace checkout.com.payment.repository.commands.Payment
{
    using checkout.com.payment.domain.Entity.Payments;
    public class PaymentDataCommand
    {
        public PaymentDataCommand(Payment payment)
        {
            this.Payment = payment;
        }

        public Payment Payment { get; }
    }
}