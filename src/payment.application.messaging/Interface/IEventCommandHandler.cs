namespace AG.PaymentApp.application.services.Events.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Core.Events;

    public interface IEventCommandHandler<TCommand, TEntity> where TCommand : Event
    {
        Task<TEntity> HandleAsync(TCommand commandEvent);
    }
}
