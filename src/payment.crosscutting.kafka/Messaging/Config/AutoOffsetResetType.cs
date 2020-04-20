namespace AG.PaymentApp.Infrastructure.Crosscutting.Kafka.Messaging.Config
{
    public enum AutoOffsetResetType
    {
        Latest = 0,
        Earliest = 1,
        Error = 2
    }
}
