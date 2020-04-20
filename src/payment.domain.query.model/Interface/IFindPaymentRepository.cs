namespace AG.PaymentApp.Domain.queries.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Query.Payments;

    public interface IFindPaymentRepository
    {
        Task<Payment> GetAsync(Guid PaymentID);
        Task<Payment> GetLastPaymentReceivedAsync(FindPaymentQuery findPaymentQuery);
        Task<IEnumerable<Payment>> GetAllAsync(FindPaymentQuery findPaymentQuery);
    }
}
