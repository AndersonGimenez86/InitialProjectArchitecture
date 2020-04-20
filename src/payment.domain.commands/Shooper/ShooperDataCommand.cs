namespace AG.PaymentApp.Domain.commands.Shoppers
{
    using System;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.ValueObject;
    using Payment.Domain.Core.Commands;

    public class ShopperCommand : Command
    {
        public ShopperCommand(Guid id, string firstname, string lastname, string email, Gender gender, Address address, DateTime birthDate)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Gender = gender;
            Address = address;
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; private set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
