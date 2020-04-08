namespace AG.PaymentApp.Domain.commands.Shoppers
{
    using AG.PaymentApp.Domain.events;

    public class ShopperDataCommand
    {
        public ShopperDataCommand(ShopperMongo shopper)
        {
            this.ShopperMongo = shopper;
        }

        public ShopperMongo ShopperMongo { get; }
    }
}
