using AG.Payment.Domain.Core.Commands;
using AG.PaymentApp.Domain.Commands.Validations.Interface;
using Ether.Outcomes;

namespace Payment.Domain.Commands.Validations.PreConditions
{
    public abstract class PreCondition<T> : IPreCondition<T> where T : Command
    {
        public abstract IOutcome Accept(T entity);
    }
}
