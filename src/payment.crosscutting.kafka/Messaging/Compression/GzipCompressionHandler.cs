namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Compression
{
    using System;
    using System.IO;
    using Confluent.Kafka;
    using ICSharpCode.SharpZipLib.GZip;

    internal class GzipCompressionHandler : ICompressionHandler
    {
        public static readonly GzipCompressionHandler Instance = new GzipCompressionHandler();

        public static readonly string CompressionType = "Gzip";

        public byte[] Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
            {
                return null;
            }

            using (var ms = new MemoryStream(data.ToArray()))
            {
                using (var outStream = new MemoryStream())
                {
                    GZip.Decompress(ms, outStream, false);

                    return outStream.ToArray();
                }
            }
        }

        public byte[] Serialize(byte[] data, SerializationContext context)
        {
            if (data == null)
                return null;

            using (var ms = new MemoryStream(data))
            {
                using (var outStream = new MemoryStream())
                {
                    GZip.Compress(ms, outStream, false);

                    return outStream.ToArray();
                }
            }
        }
    }
}
