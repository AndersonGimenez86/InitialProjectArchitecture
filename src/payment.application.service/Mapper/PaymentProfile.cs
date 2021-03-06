﻿namespace AG.PaymentApp.Application.Services.Mapper
{
    using AG.PaymentApp.Application.Services.DTO.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AutoMapper;
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<PaymentViewModel, Payment>()
                .ForMember(p => p.Id, opt => opt.MapFrom(mm => mm.PaymentID))
                .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard))
                .ForMember(p => p.Amount, opt => opt.MapFrom(mm => mm.Amount))
                .ReverseMap();
        }
    }
}
