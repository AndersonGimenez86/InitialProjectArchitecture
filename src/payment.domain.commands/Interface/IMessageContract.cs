namespace AG.PaymentApp.Domain.commands.Interface
{
    public interface IMessageContract
    {
        string Version { get; }
        string GetPartitionKey();
    }
}
