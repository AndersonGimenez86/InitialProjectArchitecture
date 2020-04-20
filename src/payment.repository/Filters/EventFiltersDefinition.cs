namespace AG.PaymentApp.Repository.Filters
{
    using System;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using MongoDB.Driver;

    internal static class EventFiltersDefinition<TFilter>
        where TFilter : EventMongo
    {
        public static FilterDefinition<TFilter> ApplyPaymentIDFilter(Guid paymentID)
        {
            if (paymentID != Guid.Empty)
            {
                return Builders<TFilter>.Filter.Eq(x => x.PaymentID, paymentID);
            }

            return FilterDefinition<TFilter>.Empty;
        }

        public static FilterDefinition<TFilter> ApplyMerchantIDFilter(Guid merchantID)
        {
            if (merchantID != Guid.Empty)
            {
                return Builders<TFilter>.Filter.Eq(x => x.MerchantID, merchantID);
            }

            return FilterDefinition<TFilter>.Empty;
        }

        public static FilterDefinition<TFilter> ApplyShooperIDFilter(Guid shopperID)
        {
            if (shopperID != Guid.Empty)
            {
                return Builders<TFilter>.Filter.Eq(x => x.ShopperID, shopperID);
            }

            return FilterDefinition<TFilter>.Empty;
        }
    }
}
