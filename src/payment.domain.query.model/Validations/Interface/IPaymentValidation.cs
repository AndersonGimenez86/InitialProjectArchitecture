// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaymentValidation.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
// </copyright>
// <summary>
// IPaymentValidation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Domain.Query.Validations.Interface
{
    using AG.PaymentApp.Domain.Entity.Payments;
    using Ether.Outcomes;

    public interface IPaymentValidation
    {
        IOutcome ValidatePayment(Payment payment);
    }
}
