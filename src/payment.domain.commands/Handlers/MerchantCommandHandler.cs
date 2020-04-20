namespace AG.PaymentApp.Domain.commands.Merchants
{
    using System;
    using System.Threading.Tasks;
    using Ag.PaymentApp.Domain.Commands.Handlers;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Core.Notifications;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AutoMapper;
    using MediatR;
    using Payment.Domain.Core.Bus;

    public class MerchantCommandHandler : CommandHandler
    {
        private readonly IMerchantRepository repository;
        private readonly IMapper typeMapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediatorHandler mediatorHandler;

        public MerchantCommandHandler(
            IMerchantRepository eventRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            INotificationHandler<DomainNotification> notifications) : base(unitOfWork, mediatorHandler, notifications)
        {
            this.repository = eventRepository;
            this.typeMapper = typeMapper;
            this.unitOfWork = unitOfWork;
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