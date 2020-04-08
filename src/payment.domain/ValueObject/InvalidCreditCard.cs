namespace AG.PaymentApp.Domain.ValueObject
{
    public class InvalidCreditCard : CreditCard
    {
        public static InvalidCreditCard Instance = new InvalidCreditCard();
    }
}