namespace AG.PaymentApp.Domain.Core.ValueObject
{
    public class InvalidCreditCard : CreditCard
    {
        public static InvalidCreditCard Instance = new InvalidCreditCard();
    }
}