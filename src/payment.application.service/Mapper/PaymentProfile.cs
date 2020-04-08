using AutoMapper;
using AG.PaymentApp.application.services.DTO.Payments;
using AG.PaymentApp.Domain.Entity.Payments;

namespace AG.PaymentApp.application.services.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<PaymentDTO, Payment>()
                .ForMember(p => p.ID, opt => opt.MapFrom(mm => mm.PaymentID))
                .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard))
                .ForMember(p => p.Amount, opt => opt.MapFrom(mm => mm.Amount))
                .ReverseMap();
        }
    }
}
