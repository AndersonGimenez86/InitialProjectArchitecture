namespace AG.PaymentApp.Domain.Commands.Interface
{
    using System.Threading.Tasks;

    public interface ICommandHandler<TEnityForCommand>
    {
        Task ExecuteAsync(TEnityForCommand entity);
    }
}
