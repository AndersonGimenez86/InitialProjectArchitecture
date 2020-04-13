using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AG.PaymentApp.application.services.DTO.Shoppers;
using AG.PaymentApp.Domain.Enum;

namespace AG.PaymentApp.application.services.Interface
{
    public interface IShopperApplicationService
    {
        Task CreateAsync(ShopperViewModel shopperDTO);
        Task<ShopperViewModel> GetAsync(Guid shopperID);
        Task<IEnumerable<ShopperViewModel>> GetShoppersByGender(Gender gender);
        Task<IEnumerable<ShopperViewModel>> GetAllAsync();
    }
}
