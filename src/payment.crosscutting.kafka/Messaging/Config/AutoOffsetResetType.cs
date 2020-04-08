namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config
{
    public enum AutoOffsetResetType
    {
        Latest = 0,
        Earliest = 1,
        Error = 2
    }
}
