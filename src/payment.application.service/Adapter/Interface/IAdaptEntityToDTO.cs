namespace AG.PaymentApp.application.services.Adapter.Interface
{
    using System.Collections.Generic;
    using AutoMapper;
    using AG.PaymentApp.Domain.Entity.Bases;

    public interface IAdaptEntityToDTO<Entity, DTO> where Entity : BaseEvent
    {
        DTO Adapt(Entity entity, IMapper typeMapper);
        IEnumerable<DTO> Adapt(IEnumerable<Entity> entities, IMapper typeMapper);
    }
}
