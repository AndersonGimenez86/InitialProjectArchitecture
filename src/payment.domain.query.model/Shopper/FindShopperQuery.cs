namespace AG.PaymentApp.Domain.Query.Shoppers
{
    using System;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.Query.Interface;

    public class FindShopperQuery : IQuery
    {
        public FindShopperQuery(Guid ShopperID, Gender Gender)
        {
            this.ShopperID = ShopperID;
            this.Gender = Gender;
        }
        public Guid ShopperID { get; }
        public Gender Gender { get; }
    }
}
