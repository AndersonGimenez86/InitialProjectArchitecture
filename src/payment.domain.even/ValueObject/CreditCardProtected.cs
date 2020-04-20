using System;

namespace AG.PaymentApp.Domain.Core.ValueObject
{
    public class CreditCardProtected
    {
        public Guid CreditCardID { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public string ExpireDate { get; set; }
        public string CreditCardType { get; set; }
        public string CVV { get; set; }

    }
}