using System;
using Payment.domain.Entity.Payments;
using Payment.domain.ValueObject;
using Microsoft.AspNetCore.DataProtection;

namespace Payment.domain.services.DataProtection
{
    public static class CreditCardDataProtection
    {
        public static void ProtectSensitiveData(IDataProtectionProvider dataProtectionProvider, Payment payment)
        {
            var protector = dataProtectionProvider.CreateProtector("Checkout.Gateway.Payment");

            var creditCardProtected = new CreditCardProtected();

            creditCardProtected.CreditCardID = Guid.NewGuid();
            creditCardProtected.CreditCardType = protector.Protect(payment.CreditCardNotMasked.CreditCardType.ToString());
            creditCardProtected.CVV = protector.Protect(payment.CreditCardNotMasked.CVV.ToString());
            creditCardProtected.ExpireDate = protector.Protect(payment.CreditCardNotMasked.ExpireDate.ToString());
            creditCardProtected.Number = protector.Protect(payment.CreditCardNotMasked.Number);
            creditCardProtected.Owner = protector.Protect(payment.CreditCardNotMasked.Owner);

            payment.TransformCreditCardInfo(creditCardProtected);
        }
    }
}
