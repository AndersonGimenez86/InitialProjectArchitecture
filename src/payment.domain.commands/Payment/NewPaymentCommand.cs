// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewPaymentCommand.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// NewPaymentCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using AG.PaymentApp.Domain.Core.Enum;
using AG.PaymentApp.Domain.Core.ValueObject;
using Payment.Domain.Commands.Validations.Interface;

namespace AG.PaymentApp.Domain.Commands.Payments
{
    public class NewPaymentCommand : PaymentCommand
    {
        private readonly IPaymentValidation paymentValidation;

        public NewPaymentCommand(Guid paymentID, Guid shopperID, Guid merchantID, CreditCard creditCard, Money amount, IPaymentValidation paymentValidation)
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
            var paymentPreConditionEvaluator = paymentValidation.ValidatePayment(this);

            if (paymentPreConditionEvaluator.Failure)
            {
                this.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, paymentPreConditionEvaluator.ToMultiLine()));
                return false;
            }

            return true;
        }
    }
}
