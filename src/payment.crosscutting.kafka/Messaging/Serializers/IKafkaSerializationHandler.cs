namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serializers
{
    using Confluent.Kafka;

    internal interface IKafkaSerializationHandler<TData> : ISerializer<TData>, IDeserializer<TData>
    {
    }
}
