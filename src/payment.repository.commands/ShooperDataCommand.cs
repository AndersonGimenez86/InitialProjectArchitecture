namespace checkout.com.payment.repository.commands.Shopper
{
    using checkout.com.payment.domain.Entity.Shoppers;

    public class ShopperDataCommand
    {
        public ShopperDataCommand(Shopper Shopper)
        {
            this.Shopper = Shopper;
        }

        public Shopper Shopper { get; }
    }
}
