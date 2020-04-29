namespace AG.PaymentApp.Domain.Query.Merchants
{
    using System;
    using AG.PaymentApp.Domain.Query.Interface;

    public class FindMerchantQuery : IQuery
    {
        public FindMerchantQuery(Guid merchantID)
        {
            this.MerchantID = merchantID;
        }

        public FindMerchantQuery(string name)
        {
            this.Name = name;
        }

        public FindMerchantQuery(Guid merchantID, string country)
        {
            this.MerchantID = merchantID;
            this.Country = country;
        }

        public FindMerchantQuery(Guid merchantID, string country, string name)
        {
            this.MerchantID = merchantID;
            this.Country = country;
            this.Name = name;
        }

        public Guid MerchantID { get; }
        public string Country { get; }
        public string Name { get; }
    }
}
