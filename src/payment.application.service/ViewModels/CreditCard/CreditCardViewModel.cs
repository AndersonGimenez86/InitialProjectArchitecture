namespace AG.PaymentApp.Application.Services.DTO.CreditCards
{
    using AG.PaymentApp.Domain.Core.Enum;
    public class CreditCardViewModelcs
    {
        public string Number { get; set; }
        public string ShopperName { get; set; }
        public string ExpireDate { get; set; }
        public CreditCardType CreditCardType { get; set; }
        public int CVV { get; set; }
    }
}
