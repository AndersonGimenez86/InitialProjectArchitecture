namespace AG.PaymentApp.Domain.commands.Merchants
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.repository.commands.Interface;

    public class MerchantCommandHandler : IMerchantCommandHandler
    {
        private readonly IMerchantRepository eventRepository;
        private readonly IMapper typeMapper;

        public MerchantCommandHandler(
            IMerchantRepository eventRepository,
            IMapper typeMapper)
        {
            this.eventRepository = eventRepository;
            this.typeMapper = typeMapper;
        }

        public async Task ExecuteAsync(Merchant merchant)
        {
            try
            {
                var merchantMongo = this.typeMapper.Map<MerchantMongo>(merchant);

                var merchantDataCommand = new MerchantDataCommand(merchantMongo);

                //save merchant event into mongoDB
                await this.eventRepository.SaveAsync(merchantDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}