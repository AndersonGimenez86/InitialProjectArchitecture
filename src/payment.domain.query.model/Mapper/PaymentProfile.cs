using AutoMapper;
using AG.PaymentApp.Domain.Entity.Payments;
using AG.PaymentApp.Domain.events;

namespace AG.PaymentApp.Domain.Query.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<PaymentMongo, Payment>()
            .ForMember(m => m.ID, opt => opt.MapFrom(mm => mm.PaymentID))
            .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard));
        }
    }
}
