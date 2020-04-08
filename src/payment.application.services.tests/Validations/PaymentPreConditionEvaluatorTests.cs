using System.Diagnostics.CodeAnalysis;
using AG.PaymentApp.application.services.DTO.Payments;
using AG.PaymentApp.Domain.ValueObject;
using Xunit;

namespace AG.PaymentApp.application.services.tests.Validations
{
    [ExcludeFromCodeCoverage]
    public class PaymentPreConditionEvaluatorTests
    {
        [Fact]
        public void PaymentAmountPreCondition_Success()
        {
            //ARRANGE

            var paymentProcessingDTO = new PaymentProcessingDTO
            {
                Amount = new Money(null, 150)
            };

            //var paymentPreConditions = new IPreCondition<PaymentProcessingDTO>[] {
            //    new PaymentAmountPreCondition(),
            //};

            //var paymentPreConditionEvaluator = new PreConditionEvaluator<PaymentProcessingDTO>(paymentPreConditions);

            ////ACT

            //var result = paymentPreConditionEvaluator.Evaluate(paymentProcessingDTO);

            ////ASSERT
            //result.Success.Should().BeTrue();
        }

        [Fact]
        public void PaymentAmountPreCondition_Fail()
        {
            //ARRANGE

            var paymentProcessingDTO = new PaymentProcessingDTO
            {
                Amount = new Money(null, 0)
            };

            //var paymentPreConditions = new PaymentPreCondition{
            //    new PaymentAmountPreCondition(),
            //};

            //var paymentPreConditionEvaluator = new PreConditionEvaluator<PaymentProcessingDTO>(paymentPreConditions);

            ////ACT

            //var result = paymentPreConditionEvaluator.Evaluate(paymentProcessingDTO);

            ////ASSERT
            //result.Failure.Should().BeTrue();
            //result.Messages.Should().NotBeNull();
        }
    }
}
