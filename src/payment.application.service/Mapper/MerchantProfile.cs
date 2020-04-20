using AutoMapper;
using AG.PaymentApp.Application.Services.DTO.Merchants;
using AG.PaymentApp.Domain.Entity.Merchants;

namespace AG.PaymentApp.Application.Services.Mapper
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            this.CreateMap<MerchantViewModel, Merchant>()
                .ForMember(m => m.Country, opt => opt.MapFrom(mm => mm.Country))
                .ForMember(m => m.Currency, opt => opt.MapFrom(mm => mm.Currency))
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.MerchantID))
                .ReverseMap();
        }
    }
}
