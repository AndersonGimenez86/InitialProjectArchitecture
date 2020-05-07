namespace AG.PaymentApp.Domain.commands.Shoppers
{
    using System;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Core.Enum;
    using AG.PaymentApp.Domain.Core.ValueObject;

    public class NewShopperCommand : ShopperCommand
    {
        private readonly ICommandValidation<ShopperCommand> commandValidation;

        public NewShopperCommand(Guid id, string firstname, string lastname, string email, Gender gender,
            Address address, DateTime birthDate, ICommandValidation<ShopperCommand> commandValidation)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
            this.BirthDate = birthDate;
            this.commandValidation = commandValidation;
        }

        public override bool IsValid()
        {
            var preConditionEvaluator = commandValidation.ValidateCommand(this);

            if (preConditionEvaluator.Failure)
            {
                this.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, preConditionEvaluator.ToMultiLine()));
                return false;
            }

            return true;
        }
    }
}
