namespace AG.PaymentApp.Domain.Commands.Interface
{
    public interface IMessageContract
    {
        string Version { get; }
        string GetPartitionKey();
    }
}
