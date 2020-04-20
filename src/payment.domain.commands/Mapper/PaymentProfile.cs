namespace AG.PaymentApp.Domain.Commands.Mapper
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AutoMapper;
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            this.CreateMap<NewPaymentCommand, Payment>()
                .ForMember(p => p.Id, opt => opt.MapFrom(mm => mm.Id))
                .ForMember(p => p.CreditCard, opt => opt.MapFrom(mm => mm.CreditCard))
                .ForMember(p => p.Amount, opt => opt.MapFrom(mm => mm.Amount))
                .ReverseMap();
        }
    }
}
