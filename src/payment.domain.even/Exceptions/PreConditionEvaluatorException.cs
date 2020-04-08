using System;

namespace AG.PaymentApp.Domain.Services.Exceptions
{
    public class PreConditionEvaluatorException : Exception
    {
        public PreConditionEvaluatorException(string message) : base(message)
        {
        }
    }
}
