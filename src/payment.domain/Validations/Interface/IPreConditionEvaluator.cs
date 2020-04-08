namespace AG.PaymentApp.Domain.Services.Validations.Interface
{
    using AG.PaymentApp.Domain.Entity.Bases;
    using Ether.Outcomes;
    public interface IPreConditionEvaluator<T> where T : BaseEvent
    {
        IOutcome Evaluate(T entity);
    }
}
