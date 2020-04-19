namespace AG.PaymentApp.Domain.Interface
{
    using System.Collections.Generic;

    public interface IMongoRepository
    {
        IDictionary<string, string> CollectionNames { get; set; }
        //IMongoDatabase Database { get; set; }
    }
}
