namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serializers
{
    using Confluent.Kafka;

    internal interface IKafkaSerializationHandler<TData> : ISerializer<TData>, IDeserializer<TData>
    {
    }
}
