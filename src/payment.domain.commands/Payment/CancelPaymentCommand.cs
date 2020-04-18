// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelPaymentCommand.cs" company="AG Software">
//   Copyright (c) AG. All rights reserved.
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
