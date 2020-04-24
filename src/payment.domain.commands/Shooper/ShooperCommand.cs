namespace AG.PaymentApp.Domain.commands.Shoppers
{
    using System;
    using AG.Payment.Domain.Core.Commands;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;

    public abstract class ShopperCommand : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
    }
}
