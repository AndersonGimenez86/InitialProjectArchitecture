namespace AG.PaymentApp.application.services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Merchants;

    public interface IMerchantApplicationService
    {
        Task CreateAsync(MerchantViewModel merchantDTO);
        Task<MerchantViewModel> GetAsync(Guid merchantID);
        Task<IEnumerable<MerchantViewModel>> GetAllAsync();
        Task<IEnumerable<MerchantViewModel>> GetMerchantsByCountry(string country);
    }
}
