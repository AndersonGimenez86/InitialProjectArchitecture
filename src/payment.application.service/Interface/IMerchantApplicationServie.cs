namespace AG.PaymentApp.application.services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Merchants;

    public interface IMerchantApplicationService
    {
        Task CreateAsync(MerchantDTO merchantDTO);
        Task<MerchantDTO> GetAsync(Guid merchantID);
        Task<IEnumerable<MerchantDTO>> GetAllAsync();
        Task<IEnumerable<MerchantDTO>> GetMerchantsByCountry(string country);
    }
}
