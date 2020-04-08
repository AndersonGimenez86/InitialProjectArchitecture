namespace AG.PaymentApp.Domain.Entity.Bases
{
    using System;

    public class BaseEvent
    {
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
