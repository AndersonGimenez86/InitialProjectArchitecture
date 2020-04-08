namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Compression
{
    using AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Serializers;

    internal interface ICompressionHandler : IKafkaSerializationHandler<byte[]>
    {
    }
}
