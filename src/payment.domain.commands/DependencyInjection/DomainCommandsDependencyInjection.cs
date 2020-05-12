namespace AG.PaymentApp.Domain.Commands.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Query.Validations;
    using global::Payment.Domain.Commands.Validations.PreConditions;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class DomainCommandsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainCommands(this IServiceCollection services)
        {
            services.TryAddScoped(typeof(IPreConditionEvaluator<>), typeof(PreConditionEvaluator<>));
            services.TryAddScoped(typeof(IPreCondition<>), typeof(PreCondition<>));
            services.TryAddScoped(typeof(ICommandValidation<>), typeof(ICommandValidation<>));
            services.TryAddScoped<IRequestHandler<NewPaymentCommand, bool>, PaymentCommandHandler>();

            return services;
        }
    }
}
