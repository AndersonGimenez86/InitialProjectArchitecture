using AutoMapper;
using AG.PaymentApp.Domain.Entity.Merchants;
using AG.PaymentApp.Domain.events;
using AG.PaymentApp.Domain.ValueObject;

namespace AG.PaymentApp.Domain.Query.Mapper
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            this.CreateMap<MerchantMongo, Merchant>()
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.MerchantID))
                .ForMember(m => m.Country, opt => opt.MapFrom(mm => new Country { Name = mm.Country }))
                .ForMember(m => m.Currency, opt => opt.MapFrom(mm => new Currency { Name = mm.Currency }));
        }
    }
}
