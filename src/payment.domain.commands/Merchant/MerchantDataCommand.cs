namespace AG.PaymentApp.Domain.commands
{
    using AG.PaymentApp.Domain.events;

    public class MerchantDataCommand
    {
        public MerchantDataCommand(MerchantMongo merchant)
        {
            this.MerchantMongo = merchant;
        }

        public MerchantMongo MerchantMongo { get; }
    }
}
