namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging
{
    using System.Threading.Tasks;

    public interface IMessageHandler<TMessage>
        where TMessage : class
    {
        Task HandleAsync(TMessage message);
    }
}
