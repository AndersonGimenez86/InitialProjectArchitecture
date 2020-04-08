using AG.PaymentApp.Domain.Entity.Payments;
using AG.PaymentApp.Domain.Services.DataProtection;
using AG.PaymentApp.Domain.Services.Exceptions;
using AG.PaymentApp.Domain.Services.Interface;
using AG.PaymentApp.Domain.Services.Validations.Interface;
using Microsoft.AspNetCore.DataProtection;

namespace AG.PaymentApp.Domain.Services.Services
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
