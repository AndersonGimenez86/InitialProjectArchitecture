namespace AG.PaymentApp.Domain.Commands.Interface
{
    using System.Collections.Generic;

    public interface IMongoRepository
    {
        IDictionary<string, string> CollectionNames { get; set; }
    }
}
