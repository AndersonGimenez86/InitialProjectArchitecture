namespace AG.PaymentApp.application.services.Mapper
{
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AutoMapper;
    public class PaymentProcessingProfile : Profile
    {
        public PaymentProcessingProfile()
        {
            this.CreateMap<PaymentProcessingViewModel, Payment>()
            .ForMember(p => p.CreditCard, opt => opt.Ignore())
            .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard));
        }
    }
}
