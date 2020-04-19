namespace AG.PaymentApp.Domain.Commands.Validations.Interface
{
    using Ether.Outcomes;
    using Payment.Domain.Core.Commands;

    public interface IPreConditionEvaluator<T> where T : Command
    {
        IOutcome Evaluate(T entity);
    }
}
