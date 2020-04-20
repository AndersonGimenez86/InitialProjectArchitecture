using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AG.PaymentApp.Application.Services.DTO.Shoppers;
using AG.PaymentApp.Domain.Core.Enum;

namespace AG.PaymentApp.Application.Services.Interface
{
    public interface IShopperApplicationService
    {
        Task CreateAsync(ShopperViewModel shopperDTO);
        Task<ShopperViewModel> GetAsync(Guid shopperID);
        Task<IEnumerable<ShopperViewModel>> GetShoppersByGender(Gender gender);
        Task<IEnumerable<ShopperViewModel>> GetAllAsync();
    }
}
