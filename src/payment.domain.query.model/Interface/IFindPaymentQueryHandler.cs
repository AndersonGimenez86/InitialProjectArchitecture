namespace AG.PaymentApp.Domain.Query.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Payments;

    public interface IFindPaymentQueryHandler : IQueryHandler<FindPaymentQuery, Payment>
    {
        Task<IEnumerable<Payment>> GetAllAsync(FindPaymentQuery query);
        Task<Payment> GetLastPaymentReceivedAsync(FindPaymentQuery query);

    }
}
