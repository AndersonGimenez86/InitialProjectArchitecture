namespace checkout.com.payment.repository.commands
{
    using checkout.com.payment.domain.Entity.Merchants;

    public class MerchantDataCommand
    {
        public MerchantDataCommand(Merchant merchant)
        {
            this.Merchant = merchant;
        }

        public Merchant Merchant { get; }
    }
}
