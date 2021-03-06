﻿namespace AG.PaymentApp.Domain.Commands.DependencyInjection
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
    public static class DomainCommandsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainCommands(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IPreConditionEvaluator<PaymentCommand>, PreConditionEvaluator<PaymentCommand>>()
                    .AddSingleton<IPreConditionEvaluator<MerchantCommand>, PreConditionEvaluator<MerchantCommand>>()
                    .AddSingleton<IPreCondition<PaymentCommand>, PaymentAmountPreCondition>()
                    .AddSingleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardCVVPreCondition>()
                    .AddSingleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardExpireDatePreCondition>()
                    .AddSingleton<IPreCondition<NewPaymentCommand>, PaymentCreditCardNumberPreCondition>()
                    .AddSingleton<ICommandValidation<PaymentCommand>, PaymentValidation>()
                    .AddSingleton<ICommandValidation<MerchantCommand>, MerchantValidation>()
                    .AddScoped<IRequestHandler<NewPaymentCommand, bool>, PaymentCommandHandler>();
        }
    }
}
