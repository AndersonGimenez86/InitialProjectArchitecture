namespace AG.PaymentApp.Domain.events
{
    using System;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.ValueObject;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    public class PaymentMongo : EventMongo
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement(nameof(PaymentID))]
        public override Guid PaymentID { get; set; }

        [BsonElement(nameof(ShopperID))]
        public override Guid ShopperID { get; set; }

        [BsonElement(nameof(MerchantID))]
        public override Guid MerchantID { get; set; }

        [BsonElement(nameof(TransactionID))]
        public Guid TransactionID { get; set; }

        [BsonElement(nameof(Amount))]
        public Money Amount { get; set; }

        [BsonElement(nameof(EventName))]
        public string EventName { get; set; }

        [BsonElement(nameof(CreditCard))]
        public CreditCardProtected CreditCard { get; set; }

        [BsonElement(nameof(Reference))]
        public string Reference { get; set; }

        [BsonElement(nameof(Status))]
        public PaymentStatus Status { get; set; }
    }
}
