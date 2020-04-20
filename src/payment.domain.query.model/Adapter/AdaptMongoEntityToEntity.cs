namespace AG.PaymentApp.Application.Services.Adapter
{
    using System.Collections.Generic;
    using AutoMapper;
    using AG.PaymentApp.Domain.events;

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
