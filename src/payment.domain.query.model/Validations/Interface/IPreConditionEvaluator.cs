namespace AG.PaymentApp.Domain.Query.Validations.Interface
{
    using AG.PaymentApp.Domain.Entity.Bases;
    using Ether.Outcomes;

    public interface IPreConditionEvaluator<T> where T : Entity
    {
        IOutcome Evaluate(T entity);
    }
}
