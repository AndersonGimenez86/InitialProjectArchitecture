namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serialization
{
    public interface IMessageSerializer<TMessage>
          where TMessage : class
    {
        string Name { get; }

        TMessage Deserialize(byte[] content);

        byte[] Serialize(TMessage message);
    }
}
