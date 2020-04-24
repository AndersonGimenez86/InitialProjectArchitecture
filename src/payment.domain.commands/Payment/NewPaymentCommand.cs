// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewPaymentCommand.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// NewPaymentCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using AG.Payment.Domain.Commands.Validations.Interface;
using AG.PaymentApp.Domain.Core.Enum;
using AG.PaymentApp.Domain.Core.ValueObject;

namespace AG.PaymentApp.Domain.Commands.Payments
{
    public class NewPaymentCommand : PaymentCommand
    {
        private readonly ICommandValidation<PaymentCommand> paymentValidation;

        public NewPaymentCommand(Guid paymentID, Guid shopperID, Guid merchantID, CreditCard creditCard,
            Money amount, ICommandValidation<PaymentCommand> paymentValidation)
        {
            this.Id = paymentID;
            this.ShopperID = shopperID;
            this.MerchantID = merchantID;
            this.CreditCard = creditCard;
            this.Amount = amount;
            this.Status = PaymentStatus.Received;
            this.paymentValidation = paymentValidation;
        }
        public CreditCard CreditCard { get; set; }

        public override bool IsValid()
        {
            var preConditionEvaluator = paymentValidation.ValidateCommand(this);

            if (preConditionEvaluator.Failure)
            {
                this.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, preConditionEvaluator.ToMultiLine()));
                return false;
            }

            return true;
        }
    }
}
