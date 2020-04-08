namespace AG.PaymentApp.Domain.events
{
    using System;
    using AG.PaymentApp.Domain.Enum;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    public class ShopperMongo : EventMongo
    {
        public static ShopperMongo CreateNew(Gender gender, Guid shopperID, string firstname, string lastname, string email, AddressMongo address)
        {
            var shopper = new ShopperMongo
            {
                ShopperID = shopperID,
                Address = address,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender
            };
            return shopper;
        }
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]

        [BsonElement(nameof(ShopperID))]
        public override Guid ShopperID { get; set; }

        [BsonElement(nameof(FirstName))]
        public string FirstName { get; private set; }

        [BsonElement(nameof(LastName))]
        public string LastName { get; private set; }

        [BsonElement(nameof(Email))]
        public string Email { get; private set; }

        [BsonElement(nameof(Gender))]
        public Gender Gender { get; private set; }

        [BsonElement(nameof(Address))]
        public AddressMongo Address { get; private set; }

        [BsonElement(nameof(BirthDate))]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, Representation = MongoDB.Bson.BsonType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
