namespace AG.PaymentApp.application.messaging.Events
{
    using System;
    using AG.PaymentApp.application.messaging.Events.Interface;

    public class CreateTransactionEvent : IEventCommand
    {
        public CreateTransactionEvent(Guid eventID, Guid transactionID, string transactionStatus)
        {
            this.EventID = eventID;
            this.TransactionID = transactionID;
            this.TransactionStatus = transactionStatus;
        }

        public Guid EventID { get; set; }
        public Guid TransactionID { get; set; }
        public string TransactionStatus { get; set; }
    }
}
