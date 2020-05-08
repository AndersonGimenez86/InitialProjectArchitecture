namespace AG.PaymentApp.Infrastructure.Crosscutting.Environment
{
    using System.Collections.Generic;

    public class DataBaseConfiguration
    {
        public Dictionary<string, DataBaseServiceConfiguration> Collections { get; set; }
        public string MongoDbConnectionString { get; set; }
        public string MongoDbName { get; set; }
    }
}
