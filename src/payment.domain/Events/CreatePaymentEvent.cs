namespace AG.PaymentApp.Domain.Events
{
    using System;
    using AG.PaymentApp.Domain.Core.Events;
    using AG.PaymentApp.Domain.Core.ValueObject;

    public class CreatePaymentEvent : Event
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
