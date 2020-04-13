using AutoMapper;
using AG.PaymentApp.application.services.DTO.Payments;
using AG.PaymentApp.Domain.Entity.Payments;

namespace AG.PaymentApp.application.services.Mapper
{
    public class PaymentProcessingProfile : Profile
    {
        public PaymentProcessingProfile()
        {
            this.CreateMap<PaymentProcessingViewModel, Payment>()
            .ForMember(p => p.CreditCard, opt => opt.Ignore())
            .ForMember(p => p.CreditCardNotMasked, opt => opt.MapFrom(mm => mm.CreditCard));
        }
    }
}
