namespace AG.PaymentApp.Domain.Commands.Interface
{
    using AG.PaymentApp.Domain.Entity.Merchants;

    public interface IMerchantCommandHandler : ICommandHandler<Merchant>
    {
    }
}
