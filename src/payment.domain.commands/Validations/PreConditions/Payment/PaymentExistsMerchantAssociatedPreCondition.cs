﻿namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Payments
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Domain.Commands.Payments;
    using AG.PaymentApp.Domain.Commands.Validations.Interface;
    using AG.PaymentApp.Domain.queries.Interface;
    using Ether.Outcomes;

    public class PaymentExistsMerchantAssociatedPreCondition : IPreCondition<PaymentCommand>
    {
        private readonly IFindMerchantRepository findMerchantRepository;

        public PaymentExistsMerchantAssociatedPreCondition(IFindMerchantRepository findMerchantRepository)
        {
            this.findMerchantRepository = findMerchantRepository;
        }

        public IOutcome Accept(PaymentCommand payment)
        {
            var merchantExists = FindMerchantByID(payment.MerchantID).GetAwaiter();

            if (merchantExists.GetResult())
            {
                return Outcomes.Success();
            }

            return Outcomes.Failure<int[]>().WithMessage($"Merchant not found to process the payment.");
        }

        private async Task<bool> FindMerchantByID(Guid merchandID)
        {
            return await this.findMerchantRepository.GetAsync(merchandID) != null;
        }
    }
}
