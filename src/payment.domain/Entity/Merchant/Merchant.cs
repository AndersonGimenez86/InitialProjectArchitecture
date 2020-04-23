namespace AG.PaymentApp.Domain.Entity.Merchants
{
    using System;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using AG.PaymentApp.Domain.Entity.Bases;

    public class Merchant : Entity
    {
        public Merchant()
        { }
        public Merchant(Guid id, string name, string acronym, Currency currency, Country country, bool isVisible, bool isOnline)
        {
            this.Id = id;
            this.Name = name;
            this.Acronym = acronym;
            this.Currency = currency;
            this.Country = country;
            this.IsVisible = IsVisible;
            this.IsOnline = IsOnline;
        }
        public string Name { get; set; }

        public string Acronym { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }

        public bool IsVisible { get; set; }

        public bool IsOnline { get; set; }
    }
}
