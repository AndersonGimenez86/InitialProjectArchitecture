namespace AG.PaymentApp.Data.commands.Mapper
{
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AutoMapper;
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            this.CreateMap<Merchant, MerchantMongo>()
                .ForMember(m => m.Country, opt => opt.MapFrom(mm => mm.Country.Name))
                .ForMember(m => m.Currency, opt => opt.MapFrom(mm => mm.Currency.Name))
                .ForMember(m => m.MerchantID, opt => opt.MapFrom(mm => mm.Id));
        }
    }
}
