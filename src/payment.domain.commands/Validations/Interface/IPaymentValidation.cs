// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaymentValidation.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// IPaymentValidation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Domain.Commands.Validations.Interface
{
    using AG.PaymentApp.Domain.Commands.Payments;
    using Ether.Outcomes;

    public interface IPaymentValidation
    {
        IOutcome ValidatePayment(NewPaymentCommand payment);
    }
}
