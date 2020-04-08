﻿namespace AG.PaymentApp.repository.Interface
{
    using System.Collections.Generic;
    using MongoDB.Driver;

    public interface IMongoRepository
    {
        IDictionary<string, string> CollectionNames { get; set; }
        IMongoDatabase Database { get; set; }
    }
}
