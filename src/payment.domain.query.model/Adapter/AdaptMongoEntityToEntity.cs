namespace AG.PaymentApp.Application.Services.Adapter
{
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Entity.Mongo;
    using AutoMapper;

    public class AdaptMongoEntityToEntity<MongoEntity, Entity> : IAdaptMongoEntityToEntity<MongoEntity, Entity> where MongoEntity : EventMongo
    {
        public Entity Adapt(MongoEntity entity, IMapper typeMapper)
        {
            return typeMapper.Map<Entity>(entity);
        }

        public IEnumerable<Entity> Adapt(IEnumerable<MongoEntity> entities, IMapper typeMapper)
        {
            return typeMapper.Map<IEnumerable<Entity>>(entities);
        }
    }
}
