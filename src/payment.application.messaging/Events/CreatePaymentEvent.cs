namespace AG.PaymentApp.application.messaging.Events
{
    using System;
    using AG.PaymentApp.application.messaging.Events.Interface;
    using AG.PaymentApp.Domain.ValueObject;

    public class CreatePaymentEvent : IEventCommand
    {
        public CreatePaymentEvent(Guid eventID, Guid shopperID, CreditCardProtected creditCard, Money amount)
        {
            this.EventID = eventID;
            this.ShopperID = shopperID;
            this.CreditCard = creditCard;
            this.Amount = amount;
        }

        public Guid EventID { get; private set; }
        public Guid ShopperID { get; private set; }
        public CreditCardProtected CreditCard { get; private set; }
        public Money Amount { get; private set; }
    }
}
