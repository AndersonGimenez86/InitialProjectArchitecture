namespace AG.PaymentApp.Domain.Entity.Mongo
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    public class EventMongo
    {
        [BsonIgnore]
        public virtual Guid PaymentID { get; set; }
        [BsonIgnore]
        public virtual Guid ShopperID { get; set; }
        [BsonIgnore]
        public virtual Guid MerchantID { get; set; }

        [BsonElement(nameof(DateCreated))]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, Representation = MongoDB.Bson.BsonType.DateTime)]
        public DateTime DateCreated { get; set; }

        [BsonElement(nameof(DateModified))]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, Representation = MongoDB.Bson.BsonType.DateTime)]
        public DateTime DateModified { get; set; }
    }
}
