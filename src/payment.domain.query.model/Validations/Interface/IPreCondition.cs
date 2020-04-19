namespace AG.PaymentApp.Domain.Query.Validations.Interface
{
    using AG.PaymentApp.Domain.Entity.Bases;
    using Ether.Outcomes;

    public interface IPreCondition<T> where T : Entity
    {
        IOutcome Accept(T entity);
    }
}
