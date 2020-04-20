namespace AG.PaymentApp.Data.Mapper
{
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.events;
    using AutoMapper;
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<Payment, PaymentMongo>()
                .ForMember(p => p.Amount, opt => opt.MapFrom(pm => pm.Amount))
                .ForMember(p => p.PaymentID, opt => opt.MapFrom(pm => pm.Id));
        }
    }
}
