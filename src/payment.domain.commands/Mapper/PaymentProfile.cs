using AutoMapper;
using AG.PaymentApp.Domain.Entity.Payments;
using AG.PaymentApp.Domain.events;

namespace AG.PaymentApp.Domain.commands.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<Payment, PaymentMongo>()
                .ForMember(p => p.Amount, opt => opt.MapFrom(pm => pm.Amount))
                .ForMember(p => p.PaymentID, opt => opt.MapFrom(pm => pm.ID));
        }
    }
}
