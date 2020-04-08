﻿namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Exceptions
{
    using System;

    public sealed class ConfigurationException : Exception
    {
        public ConfigurationException()
        {
        }

        public ConfigurationException(string message) : base(message)
        {
        }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
