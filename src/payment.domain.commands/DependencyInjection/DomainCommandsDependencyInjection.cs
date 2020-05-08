namespace AG.PaymentApp.Domain.Commands.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Commands;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Services;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Commands.Validations.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments;
    using AG.PaymentApp.Domain.Query.Validations;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class DomainCommandsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainCommands(this IServiceCollection services)
        {
            services.TryAddEnumerable(new[]
            {
                ServiceDescriptor.Singleton<IPreConditionEvaluator<PaymentCommand>, PreConditionEvaluator<PaymentCommand>>(),
                ServiceDescriptor.Singleton<IPreConditionEvaluator<MerchantCommand>, PreConditionEvaluator<MerchantCommand>>(),
                ServiceDescriptor.Singleton<IPreCondition<PaymentCommand>, PaymentAmountPreCondition>(),
                ServiceDescriptor.Singleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardCVVPreCondition>(),
                ServiceDescriptor.Singleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardExpireDatePreCondition>(),
                ServiceDescriptor.Singleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardNumberPreCondition>()
            });

            return services
                .AddSingleton<ICommandValidation<PaymentCommand>, PaymentValidation>()
                .AddSingleton<ICommandValidation<MerchantCommand>, MerchantValidation>()
                .AddScoped<IRequestHandler<NewPaymentCommand, bool>, PaymentCommandHandler>();
        }
    }
}
