namespace AG.PaymentApp.Domain.Entity.Payments
{
    using System;
    using AG.PaymentApp.Domain.Entity.Bases;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.ValueObject;

    public class Payment : BaseEvent
    {
        public Guid ShopperID { get; set; }
        public Guid MerchantID { get; set; }
        public Guid TransactionID { get; set; }
        public Money Amount { get; set; }
        public CreditCardProtected CreditCard { get; set; }
        public CreditCard CreditCardNotMasked { get; set; }
        public string Reference { get; set; }
        public PaymentStatus Status { get; set; }
        public Payment LastPaymentReceived { get; private set; } = default(Payment);

        public void AddLastPaymentReceived(Payment lastPayment)
        {
            LastPaymentReceived = lastPayment;
        }

        public void TransformCreditCardInfo(CreditCardProtected creditCardProtected)
        {
            this.CreditCard = creditCardProtected;
            this.CreditCardNotMasked = null;
        }
    }
}
