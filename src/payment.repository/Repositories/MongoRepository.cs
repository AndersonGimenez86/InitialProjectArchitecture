using System.Collections.Generic;
using System.Linq;
using AG.PaymentApp.Domain.Interface;
using AG.PaymentApp.Infrastructure.Crosscutting.Environment;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AG.PaymentApp.Repository.Repositories
{
    class MongoRepository : IMongoRepository
    {
        private readonly DataBaseSettings config;

        public MongoRepository(IOptions<DataBaseSettings> options)
        {
            this.config = options.Value;
            this.BuildMongoDatabase();
            this.LoadKnownPayloadTypes();
        }

        public IDictionary<string, string> CollectionNames { get; set; }

        public IMongoDatabase Database { get; set; }

        private void BuildMongoDatabase()
        {
            if (this.config != null && this.config.MongoDbConnectionString != null)
            {
                var client = new MongoClient(this.config.MongoDbConnectionString);

                this.Database = client.GetDatabase(this.config.MongoDbName);
            }
            else
            {
                this.Database = default(IMongoDatabase);
            }
        }

        private void LoadKnownPayloadTypes()
        {
            if (config.Collections != null)
                this.CollectionNames = config.Collections.Values.ToDictionary(setting => setting.PayloadFullyQualifiedTypeName, setting => setting.CollectionName);
        }
    }
}
