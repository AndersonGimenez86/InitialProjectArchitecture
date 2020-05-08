namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    using System.Collections.Generic;

    public interface IDataBaseConfiguration
    {
        Dictionary<string, DataBaseServiceConfiguration> Collections { get; set; }
        string MongoDbConnectionString { get; set; }
        string MongoDbName { get; set; }
    }
}