namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Merchants;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.commands.Merchants;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AutoMapper;

    public class MerchantApplicationService : IMerchantApplicationService
    {
        private readonly MerchantCommandHandler merchantCommand;
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter;

        public MerchantApplicationService(
            IFindMerchantQueryHandler findMerchantQueryHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter
            )
        {
            this.merchantCommand = merchantCommand;
            this.findMerchantQueryHandler = findMerchantQueryHandler;
            this.typeMapper = typeMapper;
            this.merchantAdapter = merchantAdapter;
        }

        public async Task CreateAsync(MerchantViewModel merchantDTO)
        {
            var merchant = ReturnMerchantFilled(merchantDTO);

            //this.merchantDomainService.ValidateMerchant(merchant);

            await this.merchantCommand.ExecuteAsync(merchant);
        }

        public async Task<MerchantViewModel> GetAsync(Guid merchantID)
        {
            var findMerchantQuery = new FindMerchantQuery(merchantID, string.Empty, string.Empty);

            var merchant = await this.findMerchantQueryHandler.GetAsync(findMerchantQuery);

            return this.merchantAdapter.Adapt(merchant, typeMapper);
        }

        public async Task<IEnumerable<MerchantViewModel>> GetAllAsync()
        {
            var findMerchantQuery = new FindMerchantQuery(Guid.Empty, string.Empty, string.Empty);

            var merchants = await this.findMerchantQueryHandler.GetAllAsync(findMerchantQuery);

            return this.merchantAdapter.Adapt(merchants, typeMapper);
        }
        public Task<IEnumerable<MerchantViewModel>> GetMerchantsByCountry(string country)
        {
            throw new NotImplementedException();
        }

        private Merchant ReturnMerchantFilled(MerchantViewModel merchantDTO)
        {
            var merchant = this.typeMapper.Map<Merchant>(merchantDTO);
            merchant.IsOnline = true;
            merchant.IsVisible = true;
            merchant.Id = merchant.Id != Guid.Empty ? merchant.Id : Guid.NewGuid();
            merchant.DateCreated = DateTime.Now;

            return merchant;
        }
    }
}