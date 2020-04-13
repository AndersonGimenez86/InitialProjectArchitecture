namespace AG.PaymentApp.application.services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter.Interface;
    using AG.PaymentApp.application.services.DTO.Merchants;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.Domain.Commands.Interface;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AG.PaymentApp.Domain.Services.Interface;

    public class MerchantApplicationService : IMerchantApplicationService
    {
        private readonly IMerchantCommandHandler merchantCommand;
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;
        private readonly IMerchantService merchantDomainService;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter;

        public MerchantApplicationService(
            IMerchantCommandHandler merchantCommand,
            IFindMerchantQueryHandler findMerchantQueryHandler,
            IMerchantService merchantDomainService,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter
            )
        {
            this.merchantCommand = merchantCommand;
            this.findMerchantQueryHandler = findMerchantQueryHandler;
            this.merchantDomainService = merchantDomainService;
            this.typeMapper = typeMapper;
            this.merchantAdapter = merchantAdapter;
        }

        public async Task CreateAsync(MerchantViewModel merchantDTO)
        {
            var merchant = ReturnMerchantFilled(merchantDTO);

            this.merchantDomainService.ValidateMerchant(merchant);

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
            merchant.ID = merchant.ID != Guid.Empty ? merchant.ID : Guid.NewGuid();
            merchant.DateCreated = DateTime.Now;

            return merchant;
        }
    }
}