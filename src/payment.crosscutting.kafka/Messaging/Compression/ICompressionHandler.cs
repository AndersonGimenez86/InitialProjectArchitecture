namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Compression
{
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serializers;

    internal interface ICompressionHandler : IKafkaSerializationHandler<byte[]>
    {
    }
}
