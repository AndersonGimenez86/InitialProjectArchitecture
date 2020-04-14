// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaymentValidation.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// IPaymentValidation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Domain.Commands.Validations.Interface
{
    using AG.PaymentApp.Domain.Commands.Payments;

    public interface IPaymentValidation
    {
        void ValidatePayment(NewPaymentCommand payment);
    }
}
