namespace Payment.domain.services.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using Payment.domain.Entity.Merchants;
    using Payment.domain.Entity.Payments;
    using Payment.domain.services.Services;
    using Payment.domain.services.Services.Interface;
    using Payment.domain.services.Validations;
    using Payment.domain.services.Validations.Interface;
    using Payment.domain.services.Validations.PreConditions.Merchant;
    using Payment.domain.services.Validations.PreConditions.Payment;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainServicesDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainServices(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IPaymentService, PaymentService>()
                    .AddSingleton<IMerchantService, MerchantService>()
                    .AddSingleton<IPreConditionEvaluator<Payment>, PreConditionEvaluator<Payment>>()
                    .AddSingleton<IPreConditionEvaluator<Merchant>, PreConditionEvaluator<Merchant>>()
                    .AddSingleton<IPreCondition<Payment>, PaymentAmountPreCondition>()
                    .AddSingleton<IPreCondition<Payment>, PaymentCreditCardCVVPreCondition>()
                    .AddSingleton<IPreCondition<Payment>, PaymentCreditCardExpireDatePreCondition>()
                    .AddSingleton<IPreCondition<Payment>, PaymentCreditCardNumberPreCondition>()
                    .AddSingleton<IPreCondition<Merchant>, MerchantUniqueIDPreCondition>()
                    .AddSingleton<IPreCondition<Merchant>, MerchantUniqueNamePreCondition>()

                    ;
        }
    }
}