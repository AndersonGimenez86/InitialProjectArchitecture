namespace AG.PaymentApp.Infrastructure.Crosscutting.Settings
{
    using System.Collections.Generic;

    public class DataBaseConfiguration : IDataBaseConfiguration
    {
        public Dictionary<string, DataBaseServiceConfiguration> Collections { get; set; }
        public string MongoDbConnectionString { get; set; }
        public string MongoDbName { get; set; }
    }
}
