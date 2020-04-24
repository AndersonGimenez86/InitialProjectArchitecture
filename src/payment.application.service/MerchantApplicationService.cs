namespace AG.PaymentApp.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.Payment.Domain.Core.Bus;
    using AG.PaymentApp.Application.Services.Adapter.Interface;
    using AG.PaymentApp.Application.Services.DTO.Merchants;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.Domain.Commands;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.Query.Interface;
    using AG.PaymentApp.Domain.Query.Merchants;
    using AutoMapper;

    public class MerchantApplicationService : IMerchantApplicationService
    {
        private readonly IMediatorHandler mediatorHandler;
        private readonly IFindMerchantQueryHandler findMerchantQueryHandler;
        private readonly IMapper typeMapper;
        private readonly IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter;

        public MerchantApplicationService(
            IFindMerchantQueryHandler findMerchantQueryHandler,
            IMediatorHandler mediatorHandler,
            IMapper typeMapper,
            IAdaptEntityToViewModel<Merchant, MerchantViewModel> merchantAdapter
            )
        {
            this.mediatorHandler = mediatorHandler;
            this.findMerchantQueryHandler = findMerchantQueryHandler;
            this.typeMapper = typeMapper;
            this.merchantAdapter = merchantAdapter;
        }

        public async Task CreateAsync(MerchantViewModel merchantDTO)
        {
            var newPaymentCommand = ReturnMerchantFilled(merchantDTO);
            await mediatorHandler.SendCommand<NewMerchantCommand>(newPaymentCommand);
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

        private NewMerchantCommand ReturnMerchantFilled(MerchantViewModel merchantViewModel)
        {
            merchantViewModel.IsOnline = true;
            merchantViewModel.IsVisible = true;
            var newPaymentCommand = this.typeMapper.Map<NewMerchantCommand>(merchantViewModel);
            newPaymentCommand.Id = newPaymentCommand.Id != Guid.Empty ? newPaymentCommand.Id : Guid.NewGuid();

            return newPaymentCommand;
        }
    }
}