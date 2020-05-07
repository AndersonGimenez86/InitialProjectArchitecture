namespace AG.PaymentApp.Domain.Commands
{
    using AG.PaymentApp.Domain.Core.ValueObject;
    using AG.Payment.Domain.Core.Commands;

    public abstract class MerchantCommand : Command
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }
    }
}
