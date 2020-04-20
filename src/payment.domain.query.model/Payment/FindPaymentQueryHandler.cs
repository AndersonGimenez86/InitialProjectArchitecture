namespace AG.PaymentApp.Domain.Query.Payments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Interface;

    public class FindPaymentQueryHandler : IFindPaymentQueryHandler
    {
        private readonly IFindPaymentRepository paymentRepository;
        private readonly IAdaptMongoEntityToEntity<PaymentMongo, Payment> paymentAdapter;
        private readonly IMapper typeMapper;

        public FindPaymentQueryHandler(
            IFindPaymentRepository paymentIntentRepository,
            IAdaptMongoEntityToEntity<PaymentMongo, Payment> paymentAdapter,
            IMapper typeMapper
            )
        {
            this.paymentRepository = paymentIntentRepository;
            this.paymentAdapter = paymentAdapter;
            this.typeMapper = typeMapper;
        }

        public async Task<Payment> GetAsync(FindPaymentQuery query)
        {
            var paymentMongo = await this.paymentRepository.GetAsync(query.PaymentID);
            return this.paymentAdapter.Adapt(paymentMongo, typeMapper);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(FindPaymentQuery query)
        {
            var paymentsMongo = await this.paymentRepository.GetAllAsync(query);
            return this.paymentAdapter.Adapt(paymentsMongo, typeMapper);
        }

        public async Task<Payment> GetLastPaymentReceivedAsync(FindPaymentQuery query)
        {
            var lastPaymentMongo = await this.paymentRepository.GetLastPaymentReceivedAsync(query);
            return this.paymentAdapter.Adapt(lastPaymentMongo, typeMapper);
        }
    }
}