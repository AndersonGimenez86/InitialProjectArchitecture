using System;
using AG.PaymentApp.Domain.ValueObject;
using Microsoft.AspNetCore.DataProtection;

namespace AG.PaymentApp.Domain.Core.DataProtection
{
    public static class CreditCardDataProtection
    {
        public static CreditCardProtected ProtectSensitiveData(IDataProtectionProvider dataProtectionProvider, CreditCard creditCard)
        {
            var protector = dataProtectionProvider.CreateProtector("AG.Gateway.Payment");

            var creditCardProtected = new CreditCardProtected();

            creditCardProtected.CreditCardID = Guid.NewGuid();
            creditCardProtected.CreditCardType = protector.Protect(creditCard.CreditCardType.ToString());
            creditCardProtected.CVV = protector.Protect(creditCard.CVV.ToString());
            creditCardProtected.ExpireDate = protector.Protect(creditCard.ExpireDate.ToString());
            creditCardProtected.Number = protector.Protect(creditCard.Number);
            creditCardProtected.Owner = protector.Protect(creditCard.Owner);

            return creditCardProtected;
        }
    }
}
