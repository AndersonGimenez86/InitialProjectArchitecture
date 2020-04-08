namespace Payment.domain.services.Services.Interface
{
    using Payment.domain.Entity.Payments;

    public interface IPaymentService
    {
        void ValidatePayment(Payment payment);
    }
}
