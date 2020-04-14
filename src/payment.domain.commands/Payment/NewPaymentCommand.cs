// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewPaymentCommand.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// NewPaymentCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using AG.PaymentApp.Domain.Enum;
using AG.PaymentApp.Domain.ValueObject;
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


        public override void IsValid()
        {
            paymentValidation.ValidatePayment(this);
        }
    }
}
