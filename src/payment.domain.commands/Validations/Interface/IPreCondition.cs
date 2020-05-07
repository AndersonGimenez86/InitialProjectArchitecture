namespace AG.PaymentApp.Domain.Commands.Validations.Interface
{
    using Ether.Outcomes;
    using AG.Payment.Domain.Core.Commands;

    public interface IPreCondition<T> where T : Command
    {
        IOutcome Accept(T entity);
    }
}
