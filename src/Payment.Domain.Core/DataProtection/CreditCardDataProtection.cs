using System;
using AG.PaymentApp.Domain.Core.ValueObject;
using Microsoft.AspNetCore.DataProtection;

namespace AG.PaymentApp.Domain.Core.DataProtection
{
    public static class CreditCardDataProtection
    {
        public static CreditCardProtected ProtectSensitiveData(IDataProtectionProvider dataProtectionProvider, CreditCard creditCard)
        {
            var protector = dataProtectionProvider.CreateProtector("AG.Gateway.Payment");

            return new CreditCardProtected
            {
                CreditCardID = Guid.NewGuid(),
                CreditCardType = protector.Protect(creditCard.CreditCardType.ToString()),
                CVV = protector.Protect(creditCard.CVV.ToString()),
                ExpireDate = protector.Protect(creditCard.ExpireDate.ToString()),
                Number = protector.Protect(creditCard.Number),
                Owner = protector.Protect(creditCard.Owner)
            };
        }
    }
}
