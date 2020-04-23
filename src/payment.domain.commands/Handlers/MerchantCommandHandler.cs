namespace AG.PaymentApp.Domain.commands.Merchants
{
    using System;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AutoMapper;
    using MediatR;

    public class MerchantCommandHandler : CommandHandler
    {
        private readonly IMerchantRepository repository;
        private readonly IMapper typeMapper;
        private readonly IMediatorHandler mediatorHandler;

        public MerchantCommandHandler(
            IMerchantRepository eventRepository,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            INotificationHandler<DomainNotification> notifications) : base(mediatorHandler, notifications)
        {
            this.repository = eventRepository;
            this.typeMapper = typeMapper;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task ExecuteAsync(Merchant merchant)
        {
            try
            {
                //var merchantMongo = this.typeMapper.Map<MerchantMongo>(merchant);

                //var merchantDataCommand = new MerchantCommand(merchantMongo);

                //save merchant event into mongoDB
                //await this.eventRepository.Add(merchantDataCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}