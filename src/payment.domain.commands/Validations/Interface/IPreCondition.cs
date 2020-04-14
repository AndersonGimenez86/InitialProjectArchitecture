namespace AG.PaymentApp.Domain.Core.Validations.Interface
{
    using Ether.Outcomes;
    using Payment.Domain.Core.Commands;

    public interface IPreCondition<T> where T : Command
    {
        IOutcome Accept(T entity);
    }
}
