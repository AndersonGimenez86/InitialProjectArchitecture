using System;

namespace Payment.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
