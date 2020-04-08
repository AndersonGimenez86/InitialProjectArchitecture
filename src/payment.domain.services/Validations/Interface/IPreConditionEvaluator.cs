namespace Payment.domain.services.Validations.Interface
{
    using Payment.domain.Entity.Bases;
    using Ether.Outcomes;
    public interface IPreConditionEvaluator<T> where T : BaseEvent
    {
        IOutcome Evaluate(T entity);
    }
}
