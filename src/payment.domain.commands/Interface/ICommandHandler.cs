namespace AG.PaymentApp.Domain.commands.Interface
{
    using System.Threading.Tasks;

    public interface ICommandHandler<TEnityForCommand>
    {
        Task ExecuteAsync(TEnityForCommand entity);
    }
}
