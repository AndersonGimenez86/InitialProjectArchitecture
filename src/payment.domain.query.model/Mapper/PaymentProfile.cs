namespace AG.PaymentApp.Domain.Query.Mapper
{
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.events;
    using AutoMapper;
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<PaymentMongo, Payment>()
            .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.PaymentID))
            .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard));
        }
    }
}
