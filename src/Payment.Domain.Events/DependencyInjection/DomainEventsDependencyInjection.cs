namespace AG.PaymentApp.Domain.Commands.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Domain.Events;
    using AG.Payment.Domain.Events.Handlers;
    using AG.PaymentApp.Domain.Core.Notifications;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainEventsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainEvents(this IServiceCollection services)
        {
            return services
                    .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
                    .AddScoped<INotificationHandler<PaymentRegisteredEvent>, PaymentEventHandler>();
        }
    }
}
