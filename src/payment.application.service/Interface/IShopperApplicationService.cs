using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AG.PaymentApp.application.services.DTO.Shoppers;
using AG.PaymentApp.Domain.Enum;

namespace AG.PaymentApp.application.services.Interface
{
    public interface IShopperApplicationService
    {
        Task CreateAsync(ShopperDTO shopperDTO);
        Task<ShopperDTO> GetAsync(Guid shopperID);
        Task<IEnumerable<ShopperDTO>> GetShoppersByGender(Gender gender);
        Task<IEnumerable<ShopperDTO>> GetAllAsync();
    }
}
