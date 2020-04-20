namespace AG.PaymentApp.Domain.Commands.Mapper
{
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AutoMapper;
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            this.CreateMap<MerchantCommand, Merchant>()
                .ForMember(m => m.Country, opt => opt.MapFrom(mm => mm.Country))
                .ForMember(m => m.Currency, opt => opt.MapFrom(mm => mm.Currency))
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.Id))
                .ReverseMap();
        }
    }
}
