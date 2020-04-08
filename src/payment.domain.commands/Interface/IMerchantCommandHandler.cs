namespace AG.PaymentApp.Domain.commands.Interface
{
    using AG.PaymentApp.Domain.Entity.Merchants;

    public interface IMerchantCommandHandler : ICommandHandler<Merchant>
    {
    }
}
