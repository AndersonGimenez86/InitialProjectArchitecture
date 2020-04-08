﻿namespace AG.PaymentApp.Domain.commands.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Entity.Payments;

    public interface IPaymentCommandHandler : ICommandHandler<Payment>
    {
        Task UpdateAsync(Payment entity);
    }
}
