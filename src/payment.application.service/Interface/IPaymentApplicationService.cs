namespace AG.PaymentApp.Application.Services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.DTO.Payments;

    public interface IPaymentApplicationService
    {
        Task<PaymentProcessingResponseViewModel> CreateAsync(PaymentProcessingViewModel paymentProcessingDTO);
        Task<PaymentViewModel> GetAsync(Guid paymentID);
        Task<IEnumerable<PaymentViewModel>> GetAllAsync();
        Task<PaymentViewModel> GetLastPaymentReceivedAsync(Guid shopperID);
    }
}
