namespace Payment.domain.services.Validations
{
    using System.Collections.Generic;
    using Payment.domain.Entity.Bases;
    using Payment.domain.services.Validations.Interface;
    using Ether.Outcomes;

    public class PreConditionEvaluator<T> : IPreConditionEvaluator<T> where T : BaseEvent
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