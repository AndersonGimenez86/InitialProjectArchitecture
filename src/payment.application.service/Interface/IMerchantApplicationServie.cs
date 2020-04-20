namespace AG.PaymentApp.Application.Services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.DTO.Merchants;

    public interface IMerchantApplicationService
    {
        Task CreateAsync(MerchantViewModel merchantDTO);
        Task<MerchantViewModel> GetAsync(Guid merchantID);
        Task<IEnumerable<MerchantViewModel>> GetAllAsync();
        Task<IEnumerable<MerchantViewModel>> GetMerchantsByCountry(string country);
    }
}
