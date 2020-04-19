namespace AG.PaymentApp.Domain.commands
{
    using AG.PaymentApp.Domain.events;
    using Payment.Domain.Core.Commands;

    public class MerchantCommand : Command
    {
        public MerchantCommand(MerchantMongo merchant)
        {
            this.MerchantMongo = merchant;
        }

        public string Name { get; set; }
        public MerchantMongo MerchantMongo { get; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
