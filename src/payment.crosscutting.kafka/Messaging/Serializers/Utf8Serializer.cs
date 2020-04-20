namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config.Serializers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Serializers;
    using Confluent.Kafka;

    [ExcludeFromCodeCoverage]
    internal class Utf8Serializer : IKafkaSerializationHandler<string>
    {
        private static readonly Encoding Encoder = Encoding.UTF8;

        public static readonly Utf8Serializer Instance = new Utf8Serializer();

        public byte[] Serialize(string data, SerializationContext context)
        {
            return Encoder.GetBytes(data);
        }

        public string Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull || data.IsEmpty)
            {
                return default;
            }

            return Encoder.GetString(data.ToArray());
        }
    }
}
