namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serialization
{
    public interface IMessageSerializer<TMessage>
          where TMessage : class
    {
        string Name { get; }

        TMessage Deserialize(byte[] content);

        byte[] Serialize(TMessage message);
    }
}
