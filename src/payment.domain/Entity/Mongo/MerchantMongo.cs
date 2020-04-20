namespace AG.PaymentApp.Domain.Entity.Mongo
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    [BsonIgnoreExtraElements]
    public class MerchantMongo : EventMongo
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement(nameof(MerchantID))]
        public override Guid MerchantID { get; set; }

        [BsonElement(nameof(Name))]
        public string Name { get; set; }

        [BsonElement(nameof(Acronym))]
        public string Acronym { get; set; }

        [BsonElement(nameof(Currency))]
        public string Currency { get; set; }

        [BsonElement(nameof(Country))]
        public string Country { get; set; }

        [BsonElement(nameof(IsVisible))]
        public bool IsVisible { get; set; }

        [BsonElement(nameof(IsOnline))]
        public bool IsOnline { get; set; }
    }
}