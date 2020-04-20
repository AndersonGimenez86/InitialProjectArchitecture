namespace AG.PaymentApp.Domain.Events
{
    using System;
    using AG.PaymentApp.Domain.Core.Events;

    public class CreateTransactionEvent : Event
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
