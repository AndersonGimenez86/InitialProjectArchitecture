namespace AG.PaymentApp.Infrastructure.Crosscutting.Environment
{
    using System.Collections.Generic;

    public class DataBaseSettings
    {
        public Dictionary<string, DataBaseServiceSettings> Collections { get; set; }
        public string MongoDbConnectionString { get; set; }
        public string MongoDbName { get; set; }
    }
}
