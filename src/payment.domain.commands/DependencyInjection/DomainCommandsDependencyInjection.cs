namespace AG.PaymentApp.Domain.commands.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.commands.Merchants;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.commands.Shoopers;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainCommandsDependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection SetupDomainCommands(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IPaymentCommandHandler, PaymentCommandHandler>()
                    .AddSingleton<IShopperCommandHandler, ShopperCommandHandler>()
                    .AddSingleton<IMerchantCommandHandler, MerchantCommandHandler>();
        }
    }
}
