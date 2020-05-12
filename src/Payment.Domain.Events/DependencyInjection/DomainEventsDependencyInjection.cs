namespace AG.PaymentApp.Domain.Commands.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.Payment.Domain.Events;
    using AG.Payment.Domain.Events.Handlers;
    using AG.PaymentApp.Domain.Core.Notifications;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class DomainEventsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainEvents(this IServiceCollection services)
        {
            services.TryAddEnumerable(new[]
           {
                ServiceDescriptor.Scoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>(),
                ServiceDescriptor.Scoped<INotificationHandler<PaymentRegisteredEvent>, PaymentEventHandler>()
            });
            return services;
        }
    }
}
