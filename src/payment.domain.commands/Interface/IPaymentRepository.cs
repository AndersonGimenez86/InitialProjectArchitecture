namespace AG.PaymentApp.Domain.Commands.Interface
{
    using AG.PaymentApp.Domain.Entity.Payments;

    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
