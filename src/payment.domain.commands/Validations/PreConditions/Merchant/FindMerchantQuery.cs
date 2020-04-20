using System;

namespace AG.PaymentApp.Domain.Commands.Validations.PreConditions.Merchant
{
    internal class FindMerchantQueryValidation
    {
        private Guid iD;

        public FindMerchantQueryValidation(Guid iD)
        {
            this.iD = iD;
        }
    }
}