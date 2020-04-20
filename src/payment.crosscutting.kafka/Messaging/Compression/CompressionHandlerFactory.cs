namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Compression
{
    using System;
    using System.Collections.Generic;

    internal static class CompressionHandlerFactory
    {
        private static readonly Dictionary<string, ICompressionHandler> compressionHandlers = new Dictionary<string, ICompressionHandler>(StringComparer.OrdinalIgnoreCase)
        {
            [GzipCompressionHandler.CompressionType] = GzipCompressionHandler.Instance
        };

        public static bool ResolveCompressionHandler(string compressionType, out ICompressionHandler compressionHandler)
        {
            compressionHandler = null;

            if (!IsCompressionValid(compressionType))
            {
                return false;
            }

            compressionHandler = GetCompressionHandler(compressionType);
            return true;
        }

        public static bool IsCompressionValid(string compressionType)
        {
            return !(string.IsNullOrWhiteSpace(compressionType)
                || string.Equals("Null", compressionType, StringComparison.OrdinalIgnoreCase));
        }

        public static ICompressionHandler GetCompressionHandler(string compressionType)
        {
            if (!compressionHandlers.ContainsKey(compressionType))
            {
                throw new NotSupportedException($"Compression type not supported. {compressionType}");
            }

            return compressionHandlers[compressionType];
        }
    }
}
