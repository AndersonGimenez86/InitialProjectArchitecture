namespace AG.PaymentApp.Domain.Commands
{
    using System;
    using AG.Payment.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.Core.ValueObject;
    using FluentValidation.Results;

    public class NewMerchantCommand : MerchantCommand
    {
        private readonly ICommandValidation<MerchantCommand> merchantValidation;
        public NewMerchantCommand(Guid id, string name, string acronym, Currency currency, Country country,
            bool isVisible, bool isOnline, ICommandValidation<MerchantCommand> merchantValidation)
        {
            this.Id = id;
            this.Name = name;
            this.Acronym = acronym;
            this.Currency = currency;
            this.Country = country;
            this.IsVisible = IsVisible;
            this.IsOnline = IsOnline;
            this.merchantValidation = merchantValidation;
        }

        public bool IsVisible { get; set; }
        public bool IsOnline { get; set; }
        public override bool IsValid()
        {
            var preConditionEvaluator = merchantValidation.ValidateCommand(this);

            if (preConditionEvaluator.Failure)
            {
                this.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, preConditionEvaluator.ToMultiLine()));
                return false;
            }
            return true;
        }
    }
}
