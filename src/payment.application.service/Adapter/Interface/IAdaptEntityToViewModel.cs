namespace AG.PaymentApp.application.services.Adapter.Interface
{
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Entity.Bases;
    using AutoMapper;

    public interface IAdaptEntityToViewModel<Entity, DTO> where Entity : BaseEvent
    {
        DTO Adapt(Entity entity, IMapper typeMapper);
        IEnumerable<DTO> Adapt(IEnumerable<Entity> entities, IMapper typeMapper);
    }
}
