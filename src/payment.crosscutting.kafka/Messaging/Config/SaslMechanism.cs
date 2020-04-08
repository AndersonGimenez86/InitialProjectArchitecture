namespace AG.PaymentApp.infrastructure.crosscutting.kafka.Messaging.Config
{
    public enum SaslMechanism
    {
        Gssapi = 0,
        Plain = 1,
        ScramSha256 = 2,
        ScramSha512 = 3
    }
}
