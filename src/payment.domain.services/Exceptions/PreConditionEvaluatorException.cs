using System;

namespace Payment.domain.services.Exceptions
{
    public class PreConditionEvaluatorException : Exception
    {
        public PreConditionEvaluatorException(string message) : base(message)
        {
        }
    }
}
