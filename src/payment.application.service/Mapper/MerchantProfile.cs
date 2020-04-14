﻿using AutoMapper;
using AG.PaymentApp.application.services.DTO.Merchants;
using AG.PaymentApp.Domain.Entity.Merchants;

namespace AG.PaymentApp.application.services.Mapper
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            this.CreateMap<MerchantViewModel, Merchant>()
                .ForMember(m => m.Country, opt => opt.MapFrom(mm => mm.Country))
                .ForMember(m => m.Currency, opt => opt.MapFrom(mm => mm.Currency))
                .ForMember(m => m.ID, opt => opt.MapFrom(mm => mm.MerchantID))
                .ReverseMap();
        }
    }
}