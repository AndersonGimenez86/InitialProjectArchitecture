namespace AG.PaymentApp.Domain.Commands.Mapper
{
    using AG.PaymentApp.Domain.commands.Shoppers;
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AutoMapper;

    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            this.CreateMap<ShopperCommand, Shopper>()
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.Id))
                .ForMember(s => s.Gender, opt => opt.MapFrom(mm => mm.Gender))
                .ForMember(s => s.Address, opt => opt.MapFrom(mm => mm.Address))
                .ReverseMap();
        }
    }
}
