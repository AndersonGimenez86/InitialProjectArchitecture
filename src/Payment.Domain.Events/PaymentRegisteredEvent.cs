using System;
using AG.PaymentApp.Domain.Core.Events;
using AG.PaymentApp.Domain.Core.ValueObject;

namespace AG.Payment.Domain.Events
{
    public class PaymentRegisteredEvent : Event
    {
        public PaymentRegisteredEvent(Guid shopperID, Guid merchantID, Guid transactionID, Money amount, CreditCardProtected creditCard)
        {
            this.ShopperID = shopperID;
            this.MerchantID = merchantID;
            this.TransactionID = transactionID;
            this.Amount = amount;
            this.CreditCard = creditCard;
        }
        public Guid ShopperID { get; set; }
        public Guid MerchantID { get; set; }
        public Guid TransactionID { get; set; }
        public Money Amount { get; set; }
        public CreditCardProtected CreditCard { get; set; }
    }
}
