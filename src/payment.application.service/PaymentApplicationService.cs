namespace AG.PaymentApp.application.services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.messaging.Events;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.application.services.Events.Interface;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.crosscutting.kafka.Messaging.Producers.Interface;
    using AG.PaymentApp.Domain.commands.Interface;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Domain.Services.Interface;
    using AutoMapper;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IFindPaymentQueryHandler findPaymentQueryHandler;
        private readonly IPaymentCommandHandler paymentCommand;
        private readonly IEventCommandHandler<CreatePaymentEvent, Payment> paymentEventCommand;
        private readonly ITopicProducer<CreatePaymentEvent> topicProducer;
        private readonly IPaymentService paymentDomainService;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToDTO<Payment, PaymentDTO> paymentAdapter;

        public PaymentApplicationService(
            IFindPaymentQueryHandler findPaymentQueryHandler,
            IPaymentCommandHandler paymentCommand,
            IEventCommandHandler<CreatePaymentEvent, Payment> paymentEventCommand,
            ITopicProducer<CreatePaymentEvent> topicProducer,
            IPaymentService paymentDomainService,
            IMapper typeMapper,
            IAdaptEntityToDTO<Payment, PaymentDTO> paymentAdapter
            )
        {
            this.paymentCommand = paymentCommand;
            this.paymentEventCommand = paymentEventCommand;
            this.findPaymentQueryHandler = findPaymentQueryHandler;
            this.topicProducer = topicProducer;
            this.paymentDomainService = paymentDomainService;
            this.typeMapper = typeMapper;
            this.paymentAdapter = paymentAdapter;
        }

        public async Task<PaymentProcessingResponseDTO> CreateAsync(PaymentProcessingDTO paymentProcessingDTO)
        {
            var payment = GetPaymentFilled(paymentProcessingDTO);

            paymentDomainService.ValidatePayment(payment);

            var createPaymentEvent = new CreatePaymentEvent(payment.ID, payment.ShopperID, payment.CreditCard, payment.Amount);

            var lastPayment = await this.paymentEventCommand.HandleAsync(createPaymentEvent);
            payment.AddLastPaymentReceived(lastPayment);

            //save payment in mongoDB
            await this.paymentCommand.ExecuteAsync(payment);

            //produce event for acquiring bank consumes                
            var kafkaResponse = await this.topicProducer.ProduceAsync(payment.ID.ToString(), createPaymentEvent);

            //update payment status to processing
            if (kafkaResponse.Success)
            {
                payment.Status = PaymentStatus.Processing;
                await this.paymentCommand.UpdateAsync(payment);
            }

            var paymentProcessingResponseDTO = new PaymentProcessingResponseDTO
            {
                PaymentID = payment.ID,
                PaymentStatus = payment.Status
            };

            return paymentProcessingResponseDTO;
        }

        public async Task<PaymentDTO> GetAsync(Guid paymentID)
        {
            var findMerchantQuery = new FindPaymentQuery(paymentID);

            var payment = await this.findPaymentQueryHandler.GetAsync(findMerchantQuery);

            return paymentAdapter.Adapt(payment, typeMapper);
        }
        public async Task<IEnumerable<PaymentDTO>> GetAllAsync()
        {
            var findPaymentQuery = new FindPaymentQuery();

            var payments = await this.findPaymentQueryHandler.GetAllAsync(findPaymentQuery);

            return paymentAdapter.Adapt(payments, typeMapper);
        }

        public async Task<PaymentDTO> GetLastPaymentReceivedAsync(Guid shopperID)
        {
            var findPaymentQuery = new FindPaymentQuery(Guid.Empty, Guid.Empty, shopperID);

            var payment = await this.findPaymentQueryHandler.GetLastPaymentReceivedAsync(findPaymentQuery);

            return paymentAdapter.Adapt(payment, typeMapper);
        }

        private Payment GetPaymentFilled(PaymentProcessingDTO paymentProcessingDTO)
        {
            var payment = this.typeMapper.Map<Payment>(paymentProcessingDTO);
            payment.ID = payment.ID != Guid.Empty ? payment.ID : Guid.NewGuid();
            payment.DateCreated = DateTime.Now;
            payment.Status = PaymentStatus.Received;
            payment.Reference = $"payment for merchant {payment.MerchantID} from shopper {payment.ShopperID}";

            return payment;
        }
    }
}
