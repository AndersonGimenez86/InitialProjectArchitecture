using AutoMapper;
using AG.PaymentApp.Application.Services.DTO.Shoppers;
using AG.PaymentApp.Domain.Entity.Shoppers;

namespace AG.PaymentApp.Application.Services.Mapper
{
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            this.CreateMap<ShopperViewModel, Shopper>()
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.ShopperID))
                .ForMember(s => s.Gender, opt => opt.MapFrom(mm => mm.Gender))
                .ReverseMap();
        }
    }
}
