namespace AG.PaymentApp.Domain.events
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    public class AddressMongo
    {
        public static AddressMongo Create(Guid addressID, string street, string number, string city, string zip, string country, DateTime dateCreated)
        {
            var address = new AddressMongo { AddressID = addressID, Street = street, Number = number, City = city, Zip = zip, Country = country, DateCreated = dateCreated };
            return address;
        }

        [BsonElement(nameof(AddressID))]
        public Guid AddressID { get; set; }

        [BsonElement(nameof(Street))]
        public string Street { get; set; }

        [BsonElement(nameof(Number))]
        public string Number { get; set; }

        [BsonElement(nameof(City))]
        public string City { get; set; }

        [BsonElement(nameof(Zip))]
        public string Zip { get; set; }

        [BsonElement(nameof(Country))]
        public string Country { get; set; }

        [BsonElement(nameof(DateCreated))]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, Representation = MongoDB.Bson.BsonType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}
