namespace AG.PaymentApp.Domain.Entity.Merchants
{
    using AG.PaymentApp.Domain.Entity.Bases;
    using AG.PaymentApp.Domain.ValueObject;
    public class Merchant : Entity
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }

        public bool IsVisible { get; set; }

        public bool IsOnline { get; set; }
    }
}
