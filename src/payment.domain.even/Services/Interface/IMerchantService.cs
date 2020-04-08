namespace AG.PaymentApp.Domain.Services.Interface
{
    using AG.PaymentApp.Domain.Entity.Merchants;

    public interface IMerchantService
    {
        void ValidateMerchant(Merchant merchant);
    }
}
