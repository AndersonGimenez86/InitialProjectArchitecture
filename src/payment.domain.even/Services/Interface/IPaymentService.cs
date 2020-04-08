namespace AG.PaymentApp.Domain.Services.Interface
{
    using AG.PaymentApp.Domain.Entity.Payments;

    public interface IPaymentService
    {
        void ValidatePayment(Payment payment);
    }
}
