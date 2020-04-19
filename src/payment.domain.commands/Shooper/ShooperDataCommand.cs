namespace AG.PaymentApp.Domain.commands.Shoppers
{
    using AG.PaymentApp.Domain.events;
    using Payment.Domain.Core.Commands;

    public class ShopperCommand : Command
    {
        public ShopperCommand(ShopperMongo shopper)
        {
            this.ShopperMongo = shopper;
        }

        public ShopperMongo ShopperMongo { get; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
