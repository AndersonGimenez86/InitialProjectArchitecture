namespace AG.PaymentApp.Domain.Entity.Bases
{
    using System;

    public class BaseEvent
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
