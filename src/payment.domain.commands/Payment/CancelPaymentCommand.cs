// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelPaymentCommand.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// CancelPaymentCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Payment.Domain.Commands.Payment
{
    using System;
    using AG.PaymentApp.Domain.Commands.Payments;

    public class CancelPaymentCommand : PaymentCommand
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
