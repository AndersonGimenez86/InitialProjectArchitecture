namespace AG.PaymentApp.application.services.Events.Interface
{
    using System.Threading.Tasks;
    using AG.PaymentApp.application.messaging.Events.Interface;

    public interface IEventCommandHandler<TCommand, TEntity> where TCommand : IEventCommand
    {
        Task<TEntity> HandleAsync(TCommand commandEvent);
    }
}
