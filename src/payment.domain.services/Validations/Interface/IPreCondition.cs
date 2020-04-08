namespace Payment.domain.services.Validations.Interface
{
    using Payment.domain.Entity.Bases;
    using Ether.Outcomes;
    public interface IPreCondition<T> where T : BaseEvent
    {
        IOutcome Accept(T entity);
    }
}
