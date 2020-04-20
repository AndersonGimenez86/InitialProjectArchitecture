namespace AG.PaymentApp.Application.Services.DTO.Payments
{
    using System;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.ValueObject;

    public class PaymentViewModel
    {
        public Guid PaymentID { get; set; }
        public Money Amount { get; set; }
        public Currency Currency { get; set; }
        public CreditCardProtected CreditCard { get; set; }
        public Guid MerchantID { get; set; }
        public Guid ShopperID { get; set; }
        public Guid TransactionID { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
