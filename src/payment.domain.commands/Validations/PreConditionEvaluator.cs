namespace AG.PaymentApp.Domain.Query.Validations
{
    using System.Collections.Generic;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using Ether.Outcomes;
    using AG.Payment.Domain.Core.Commands;

    public class PreConditionEvaluator<T> : IPreConditionEvaluator<T> where T : Command
    {
        private readonly IEnumerable<IPreCondition<T>> objectPreConditions;

        public PreConditionEvaluator(IEnumerable<IPreCondition<T>> objectPreConditions)
        {
            this.objectPreConditions = objectPreConditions;
        }

        public virtual IOutcome Evaluate(T objectDTO)
        {
            IOutcome result = default(IOutcome);

            foreach (var precondition in this.objectPreConditions)
            {
                result = precondition.Accept(objectDTO);

                if (result.Failure)
                {
                    return Outcomes.Failure().FromOutcome(result);
                }
            }

            return result;
        }
    }
}