namespace AG.PaymentApp.Domain.Services.Validations.Interface
{
    using AG.PaymentApp.Domain.Entity.Bases;
    using Ether.Outcomes;
    public interface IPreCondition<T> where T : BaseEvent
    {
        IOutcome Accept(T entity);
    }
}
