﻿namespace AG.PaymentApp.application.services.Adapter
{
    using System.Collections.Generic;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.Domain.Entity.Bases;
    public class AdaptEntityToDTO<Entity, DTO> : IAdaptEntityToDTO<Entity, DTO> where Entity : BaseEvent
    {
        public DTO Adapt(Entity entity, IMapper typeMapper)
        {
            return typeMapper.Map<DTO>(entity);
        }

        public IEnumerable<DTO> Adapt(IEnumerable<Entity> entities, IMapper typeMapper)
        {
            return typeMapper.Map<IEnumerable<DTO>>(entities);
        }
    }
}
