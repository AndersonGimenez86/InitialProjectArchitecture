namespace Payment.domain.services.Services.Interface
{
    using Payment.domain.Entity.Merchants;

    public interface IMerchantService
    {
        void ValidateMerchant(Merchant merchant);
    }
}
