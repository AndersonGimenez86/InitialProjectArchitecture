namespace AG.PaymentApp.Application.Services.Adapter
{
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AutoMapper;

    public interface IAdaptMongoEntityToEntity<MongoEntity, Entity> where MongoEntity : EventMongo
    {
        Entity Adapt(MongoEntity entity, IMapper typeMapper);
        IEnumerable<Entity> Adapt(IEnumerable<MongoEntity> entities, IMapper typeMapper);
    }
}
