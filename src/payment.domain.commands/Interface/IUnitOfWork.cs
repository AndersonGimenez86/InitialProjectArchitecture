namespace AG.PaymentApp.Domain.Commands.Interface
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
