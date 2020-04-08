namespace AG.PaymentApp.Domain.Services.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Services.Interface;
    using AG.PaymentApp.Domain.Services.Services;
    using AG.PaymentApp.Domain.Services.Validations;
    using AG.PaymentApp.Domain.Services.Validations.Interface;
    using AG.PaymentApp.Domain.Services.Validations.PreConditions.Payment;
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
                    .AddSingleton<IPreCondition<Payment>, PaymentCreditCardNumberPreCondition>();
        }
    }
}