using AutoMapper;
using AG.PaymentApp.application.services.DTO.Shoppers;
using AG.PaymentApp.Domain.Entity.Shoppers;

namespace AG.PaymentApp.application.services.Mapper
{
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            this.CreateMap<ShopperDTO, Shopper>()
                .ForMember(m => m.ID, opt => opt.MapFrom(mm => mm.ShopperID))
                .ForMember(s => s.Gender, opt => opt.MapFrom(mm => mm.Gender))
                .ReverseMap();
        }
    }
}
