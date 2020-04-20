namespace AG.PaymentApp.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Repository.Filters;
    using AG.PaymentApp.Repository.Interface;
    using AutoMapper;
    using MongoDB.Driver;

    public class PaymentRepository : IPaymentRepository, IFindPaymentRepository
    {
        private readonly IPaymentRepositoryStartup eventPaymentRepositoryStartup;
        private readonly IMongoCollection<PaymentMongo> paymentEvents;
        private readonly IMapper typeMapper;

        public PaymentRepository(IPaymentRepositoryStartup eventPaymentRepositoryStartup,
            IMapper typeMapper)
        {
            this.eventPaymentRepositoryStartup = eventPaymentRepositoryStartup;
            this.typeMapper = typeMapper;
            this.paymentEvents = this.GetPaymentCollection();
        }
        public async Task SaveAsync(Payment payment)
        {
            var paymentMongo = this.typeMapper.Map<PaymentMongo>(payment);
            await this.paymentEvents.InsertOneAsync(paymentMongo).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Payment payment)
        {
            var paymentMongo = this.typeMapper.Map<PaymentMongo>(payment);

            var options = new FindOneAndReplaceOptions<PaymentMongo>
            {
                IsUpsert = true
            };

            var paymentFilter = EventFiltersDefinition<PaymentMongo>.ApplyPaymentIDFilter(paymentMongo.PaymentID);

            paymentMongo.DateModified = DateTime.Now;
            await this.paymentEvents.FindOneAndReplaceAsync(paymentFilter, paymentMongo, options).ConfigureAwait(false);
        }

        public async Task<Payment> GetLastPaymentReceivedAsync(FindPaymentQuery findPaymentQuery)
        {
            return (await GetAllAsync(findPaymentQuery)).FirstOrDefault<Payment>();
        }

        public async Task<Payment> GetAsync(Guid paymentID)
        {
            var findPaymentQuery = new FindPaymentQuery(paymentID);
            return (await GetAllAsync(findPaymentQuery)).FirstOrDefault<Payment>();
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(FindPaymentQuery findPaymentQuery)
        {
            var paymentFilter = EventFiltersDefinition<PaymentMongo>.ApplyPaymentIDFilter(findPaymentQuery.PaymentID);

            var merchantFilter = EventFiltersDefinition<PaymentMongo>.ApplyMerchantIDFilter(findPaymentQuery.MerchantID);

            var shopperFilter = EventFiltersDefinition<PaymentMongo>.ApplyShooperIDFilter(findPaymentQuery.ShopperID);

            var options = new FindOptions<PaymentMongo>
            {
                Sort = Builders<PaymentMongo>.Sort.Descending(p => p.DateCreated)
            };

            var payments = await this.paymentEvents
                .FindAsync(paymentFilter & merchantFilter & shopperFilter, options)
                .Result.ToListAsync()
                .ConfigureAwait(false);

            return this.typeMapper.Map<IEnumerable<Payment>>(payments);
        }

        private IMongoCollection<PaymentMongo> GetPaymentCollection()
        {
            return this.eventPaymentRepositoryStartup.GetMongoCollection();
        }
    }
}
