namespace AG.PaymentApp.Domain.commands.Merchants
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.Interface;
    using AutoMapper;
    using MediatR;
    using Payment.Domain.Commands.Handlers;
    using Payment.Domain.Core.Bus;
    using Payment.Domain.Interface;

    public class MerchantCommandHandler : CommandHandler
    {
        private readonly IRepository<MerchantCommand> eventRepository;
        private readonly IMapper typeMapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;

        public MerchantCommandHandler(
            IRepository<MerchantCommand> eventRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.eventRepository = eventRepository;
            this.typeMapper = typeMapper;
            this.unitOfWork = unitOfWork;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task ExecuteAsync(Merchant merchant)
        {
            try
            {
                var merchantMongo = this.typeMapper.Map<MerchantMongo>(merchant);

                var merchantDataCommand = new MerchantCommand(merchantMongo);

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