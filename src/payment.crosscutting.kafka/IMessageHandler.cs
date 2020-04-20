namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging
{
    using System.Threading.Tasks;

    public interface IMessageHandler<TMessage>
        where TMessage : class
    {
        Task HandleAsync(TMessage message);
    }
}
