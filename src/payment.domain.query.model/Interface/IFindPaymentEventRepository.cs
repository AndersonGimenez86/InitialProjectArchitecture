namespace AG.PaymentApp.Domain.queries.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Query.Payments;

    public interface IFindPaymentEventRepository
    {
        Task<PaymentMongo> GetAsync(Guid PaymentID);
        Task<PaymentMongo> GetLastPaymentReceivedAsync(FindPaymentQuery findPaymentQuery);
        Task<IEnumerable<PaymentMongo>> GetAllAsync(FindPaymentQuery findPaymentQuery);
    }
}
