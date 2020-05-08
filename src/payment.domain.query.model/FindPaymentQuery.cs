namespace AG.PaymentApp.Domain.Query.Payments
{
    using System;
    using AG.PaymentApp.Domain.Query.Interface;

    public class FindPaymentQuery : IQuery
    {
        public FindPaymentQuery()
        {

        }

        public FindPaymentQuery(Guid paymentID)
        {
            this.PaymentID = paymentID;
        }
        public FindPaymentQuery(Guid paymentID, Guid merchantID)
        {
            this.PaymentID = paymentID;
            this.MerchantID = merchantID;
        }

        public FindPaymentQuery(Guid paymentID, Guid merchantID, Guid shopperID)
        {
            this.PaymentID = paymentID;
            this.MerchantID = merchantID;
            this.ShopperID = shopperID;
        }
        public Guid PaymentID { get; } = Guid.Empty;
        public Guid MerchantID { get; } = Guid.Empty;
        public Guid ShopperID { get; } = Guid.Empty;
    }
}
