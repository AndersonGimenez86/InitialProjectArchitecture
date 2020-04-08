namespace AG.PaymentApp.Domain.commands.Payments
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.commands.Interface;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.commands.Interface;

    public class PaymentCommandHandler : IPaymentCommandHandler
    {
        private readonly IPaymentEventRepository eventRepository;
        private readonly IMapper typeMapper;

        public PaymentCommandHandler(
            IPaymentEventRepository eventRepository,
            IMapper typeMapper)
        {
            this.eventRepository = eventRepository;
            this.typeMapper = typeMapper;
        }

        public async Task ExecuteAsync(Payment payment)
        {
            try
            {
                var paymentMongo = this.typeMapper.Map<PaymentMongo>(payment);

                var paymentDataCommand = new PaymentDataCommand(paymentMongo);

                //save payment event into mongoDB
                await this.eventRepository.SaveAsync(paymentDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Payment payment)
        {
            try
            {
                var paymentMongo = this.typeMapper.Map<PaymentMongo>(payment);

                var paymentDataCommand = new PaymentDataCommand(paymentMongo);

                //update payment status on mongoDB
                await this.eventRepository.UpdateAsync(paymentDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}