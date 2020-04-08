using Payment.domain.Entity.Payments;
using Payment.domain.services.DataProtection;
using Payment.domain.services.Exceptions;
using Payment.domain.services.Services.Interface;
using Payment.domain.services.Validations.Interface;
using Microsoft.AspNetCore.DataProtection;

namespace Payment.domain.services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPreConditionEvaluator<Payment> preConditionEvaluator;
        private readonly IDataProtectionProvider dataProtectionProvider;

        public PaymentService(
            IPreConditionEvaluator<Payment> preConditionEvaluator,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.preConditionEvaluator = preConditionEvaluator;
            this.dataProtectionProvider = dataProtectionProvider;
        }

        public void ValidatePayment(Payment payment)
        {
            var paymentPreConditionEvaluator = preConditionEvaluator.Evaluate(payment);

            if (paymentPreConditionEvaluator.Failure)
            {
                throw new PreConditionEvaluatorException(paymentPreConditionEvaluator.ToMultiLine(";"));
            }

            CreditCardDataProtection.ProtectSensitiveData(dataProtectionProvider, payment);
        }
    }
}
